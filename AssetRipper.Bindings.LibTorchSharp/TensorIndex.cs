using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

/// <summary>
/// Type used to represent the variety of indexing capabilities that are available in Python, and therefore to PyTorch.
/// </summary>
public readonly struct TensorIndex
{
	internal enum Kind
	{
		None,
		Single,
		Null,
		Ellipsis,
		Bool,
		Tensor,
		Slice
	}
	internal readonly long? startIndexOrBoolOrSingle;
	internal readonly long? stopIndex;
	internal readonly long? step;
	internal readonly Kind kind;
	internal readonly Tensor tensor; // Note: we do not own the reference here. The caller must ensure the lifetime.

	private TensorIndex(long? startIndexOrBoolOrSingle, long? stopIndex, long? step, Kind kind, Tensor tensor)
	{
		this.startIndexOrBoolOrSingle = startIndexOrBoolOrSingle;
		this.stopIndex = stopIndex;
		this.step = step;
		this.kind = kind;
		this.tensor = tensor;
	}

	private TensorIndex(Kind kind)
	{
		startIndexOrBoolOrSingle = null;
		stopIndex = null;
		step = null;
		this.kind = kind;
		tensor = default;
	}

	public static TensorIndex Slice(long? start = null, long? stop = null, long? step = null)
	{
		return new TensorIndex(start, stop, step, Kind.Slice, default);
	}

	public static TensorIndex Slice((int? start, int? end) range) => Slice(range.start, range.end);

	public static TensorIndex Slice(Range range)
	{
		long? start = !range.Start.IsFromEnd ? range.Start.Value : -1 * range.Start.Value;
		long? end = !range.End.IsFromEnd ? range.End.Value : (range.End.Value == 0) ? null : -1 * range.End.Value;
		return Slice(start, end);
	}

	public static TensorIndex Boolean(bool value)
	{
		return new TensorIndex(value ? 1 : 0, null, null, Kind.Bool, default);
	}

	public static TensorIndex Single(long index)
	{
		return new TensorIndex(index, null, null, Kind.Single, default);
	}

	public static TensorIndex Tensor(Tensor tensor)
	{
		return new TensorIndex(null, null, null, Kind.Tensor, tensor);
	}

	/// <summary>
	/// Gets the tensor index that represents an ellipsis, which is used to indicate the inclusion of all remaining
	/// dimensions in a tensor operation.
	/// </summary>
	/// <remarks>
	/// Use this property when you want to specify that all dimensions not explicitly indexed should be
	/// included, similar to the ellipsis syntax (...) in Python tensor libraries.
	/// </remarks>
	public static TensorIndex Ellipsis => new TensorIndex(Kind.Ellipsis);

	public static TensorIndex None => new TensorIndex(Kind.None);

	public static TensorIndex Null => new TensorIndex(Kind.Null);

	/// <summary>
	/// Gets the tensor index that represents a colon slice, which selects all elements along the corresponding dimension.
	/// </summary>
	public static TensorIndex Colon => Slice();

	public static implicit operator TensorIndex(long value)
	{
		return Single(value);
	}

	public static implicit operator TensorIndex((int? start, int? end) range) => Slice((long?)range.start, (long?)range.end);

	public static implicit operator TensorIndex(Range range)
	{
		long? start = !range.Start.IsFromEnd ? range.Start.Value : -1 * range.Start.Value;
		long? end = !range.End.IsFromEnd ? range.End.Value : (range.End.Value == 0) ? null : -1 * range.End.Value;
		return Slice(start, end);
	}

	public static implicit operator TensorIndex(Index index)
	{
		long idx = !index.IsFromEnd ? index.Value : -1 * index.Value;
		return Single(idx);
	}

	// Internal struct used in NativeMethods.TensorIndexOverloads.cs; don't use elsewhere.
	internal unsafe readonly struct EncodedIndices : IDisposable
	{
		public readonly long* ArrayKindAndStarts;
		public readonly long* ArrayStops;
		public readonly long* ArraySteps;
		public readonly Tensor* ArrayTensors;

		private EncodedIndices(long* arrayKindAndStarts, long* arrayStops, long* arraySteps, Tensor* arrayTensors)
		{
			ArrayKindAndStarts = arrayKindAndStarts;
			ArrayStops = arrayStops;
			ArraySteps = arraySteps;
			ArrayTensors = arrayTensors;
		}

		public static EncodedIndices Encode(ReadOnlySpan<TensorIndex> indices)
		{
			ValidateIndicesLength(indices);
			bool hasSliceEnd = false;
			bool hasSliceStep = false;
			bool hasTensor = false;
			int n = indices.Length;
			for (int i = 0; i < indices.Length; i++)
			{
				TensorIndex idx = indices[i];
				hasSliceEnd |= idx.kind == Kind.Slice && idx.stopIndex.HasValue;
				hasSliceStep |= idx.kind == Kind.Slice && idx.step.HasValue;
				hasTensor |= idx.kind == Kind.Tensor && !idx.tensor.IsNull;
			}

			long* arrKindAndStarts = Alloc<long>(n);
			long* arrStops = hasSliceEnd ? Alloc<long>(n) : null;
			long* arrSteps = hasSliceStep ? Alloc<long>(n) : null;
			Tensor* arrTensors = hasTensor ? Alloc<Tensor>(n) : null;
			for (int i = 0; i < indices.Length; i++)
			{
				TensorIndex idx = indices[i];
				arrKindAndStarts[i] = idx.kind switch
				{
					Kind.Null => long.MinValue,
					Kind.Bool => (idx.startIndexOrBoolOrSingle == 0) ? long.MinValue + 1 : long.MinValue + 2,
					Kind.Ellipsis => long.MinValue + 3,
					Kind.None => long.MinValue + 4,
					Kind.Tensor => long.MinValue + 5,
					Kind.Slice => idx.startIndexOrBoolOrSingle.HasValue ? (idx.startIndexOrBoolOrSingle.GetValueOrDefault() + long.MinValue / 2) : long.MinValue + 6,
					Kind.Single => idx.startIndexOrBoolOrSingle.GetValueOrDefault(),
					_ => throw new InvalidOperationException("Unreachable"),
				};
				if (arrStops != null && idx.kind == Kind.Slice)
				{
					arrStops[i] = idx.stopIndex ?? long.MinValue;
				}

				if (arrSteps != null && idx.kind == Kind.Slice)
				{
					arrSteps[i] = idx.step ?? long.MinValue;
				}

				if (arrTensors != null && idx.kind == Kind.Tensor)
				{
					arrTensors[i] = idx.tensor.IsNull ? default : idx.tensor;
				}
			}

			return new EncodedIndices(arrKindAndStarts, arrStops, arrSteps, arrTensors);

			static void ValidateIndicesLength(ReadOnlySpan<TensorIndex> indices)
			{
				if (indices.Length == 0)
				{
					throw new ArgumentException("Indices cannot be empty", nameof(indices));
				}
				if (indices.Length > 1024)
				{
					throw new ArgumentException("Too many indices", nameof(indices));
				}
			}

			static T* Alloc<T>(int length) where T : unmanaged
			{
				return (T*)NativeMemory.Alloc((nuint)length, (nuint)sizeof(T));
			}
		}

		public void Dispose()
		{
			NativeMemory.Free(ArrayKindAndStarts);
			NativeMemory.Free(ArrayStops);
			NativeMemory.Free(ArraySteps);
			NativeMemory.Free(ArrayTensors);
		}
	}
}
