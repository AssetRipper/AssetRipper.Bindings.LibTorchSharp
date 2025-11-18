using System.Numerics;

namespace AssetRipper.Bindings.LibTorchSharp;

/// <summary>
/// The element types of tensors.
/// </summary>
public enum ScalarType : sbyte
{
	Byte = 0,
	Int8 = 1,
	Int16 = 2,
	Int32 = 3,
	Int64 = 4,
	Float16 = 5,
	Float32 = 6,
	Float64 = 7,
	//ComplexFloat16 = 8,
	ComplexFloat32 = 9,
	ComplexFloat64 = 10,
	Bool = 11,
	//QInt8 = 12,
	//QUInt8 = 13,
	//QUInt32 = 14,
	BFloat16 = 15
}
internal static class ScalarTypeExtensions
{
	extension(ScalarType)
	{
		public static ScalarType Get<T>()
		{
			if (typeof(T) == typeof(byte))
				return ScalarType.Byte;
			if (typeof(T) == typeof(sbyte))
				return ScalarType.Int8;
			if (typeof(T) == typeof(short))
				return ScalarType.Int16;
			if (typeof(T) == typeof(int))
				return ScalarType.Int32;
			if (typeof(T) == typeof(long))
				return ScalarType.Int64;
			if (typeof(T) == typeof(bool))
				return ScalarType.Bool;
			if (typeof(T) == typeof(BFloat16))
				return ScalarType.BFloat16;
			if (typeof(T) == typeof(Half))
				return ScalarType.Float16;
			if (typeof(T) == typeof(float))
				return ScalarType.Float32;
			if (typeof(T) == typeof(double))
				return ScalarType.Float64;
			if (typeof(T) == typeof(Complex32))
				return ScalarType.ComplexFloat32;
			if (typeof(T) == typeof(Complex))
				return ScalarType.ComplexFloat64;

			throw new NotSupportedException($"Type '{typeof(T).FullName}' is not supported as a scalar type.");
		}
	}
}
