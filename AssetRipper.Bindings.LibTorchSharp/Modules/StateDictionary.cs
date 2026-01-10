using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly struct StateDictionary : IDisposable
{
	private readonly string? prefix;
	private readonly Dictionary<string, Tensor> tensors;
	private readonly Device device;
	private const char Separator = '.';

	// All tensors in this dictionary are considered to be owned by this dictionary,
	// so they must be disposed when we're done with it.

	private StateDictionary(string? prefix, Dictionary<string, Tensor> tensors, Device device)
	{
		this.prefix = prefix;
		this.tensors = tensors;
		this.device = device;
	}

	public StateDictionary() : this(null)
	{
	}

	public StateDictionary(Device? device)
	{
		prefix = null;
		tensors = [];
		this.device = device ?? Device.Default;
	}

	public void AddTensor(string name, Tensor tensor)
	{
		AddTensorInternal(name, tensor.IsNull ? Tensor.Null : tensor.Alias());
	}

	private void AddTensorInternal(string name, Tensor tensor)
	{
		tensors.Add(GetFullName(name), tensor);
	}

	public Tensor GetTensor(string name)
	{
		Tensor tensor = tensors[GetFullName(name)];
		return tensor.IsNull ? Tensor.Null : tensor.Alias();
	}

	public StateDictionary AddChild(string name)
	{
		return GetChild(name);
	}

	public StateDictionary AddChild(int index)
	{
		return GetChild(index);
	}

	public StateDictionary GetChild(string name)
	{
		return new StateDictionary($"{prefix}{name}{Separator}", tensors, device);
	}

	public StateDictionary GetChild(int index)
	{
		return new StateDictionary($"{prefix}{index}{Separator}", tensors, device);
	}

	public void CopyTo(NNModule module)
	{
		// Note: these properties recursively enumerate all parameters/buffers in child modules.
		foreach ((string name, Tensor p) in module.NamedParameters)
		{
			p.CopyInline(GetTensor(name), false);
			p.Dispose();
		}
		foreach ((string name, Tensor p) in module.NamedBuffers)
		{
			p.CopyInline(GetTensor(name), false);
			p.Dispose();
		}
	}

	public void CopyFrom(NNModule module)
	{
		// Note: these properties recursively enumerate all parameters/buffers in child modules.
		foreach ((string name, Tensor p) in module.NamedParameters)
		{
			AddTensorInternal(name, p);
		}
		foreach ((string name, Tensor p) in module.NamedBuffers)
		{
			AddTensorInternal(name, p);
		}
	}

	public static StateDictionary Load(string path, Device? device = null)
	{
		using FileStream stream = File.OpenRead(path);
		return Load(stream, device);
	}

	public static StateDictionary Load(Stream stream, Device? device = null)
	{
		StateDictionary dictionary = new(device);
		using BinaryReader reader = new(stream, System.Text.Encoding.UTF8, true);
		reader.ReadInt64(); // Magic
		for (int remainingTensors = reader.ReadInt32(); remainingTensors > 0; remainingTensors--)
		{
			string key = reader.ReadString();

			ScalarType scalarType = (ScalarType)reader.ReadSByte();
			bool requires_grad = reader.ReadBoolean();
			byte element_size = reader.ReadByte();

			int lengthCount = reader.ReadInt32();
			long[] lengths = new long[lengthCount];
			for (int i = 0; i < lengthCount; i++)
			{
				lengths[i] = reader.ReadInt64();
			}

			long element_count = reader.ReadInt64();
			long total_bytes = element_count * element_size;
			if (total_bytes > Array.MaxLength)
			{
				throw new NotSupportedException();
			}
			else if (total_bytes is 0)
			{
				dictionary.tensors.Add(key, Tensor.Null);
			}
			else
			{
				byte[] buffer = new byte[total_bytes];
				reader.ReadExactly(buffer);

				Tensor tensor = Tensor.Create(buffer, lengths, scalarType, scalarType, requires_grad, device);

				dictionary.tensors.Add(key, tensor);
			}
		}
		return dictionary;
	}

	public void Save(string path)
	{
		using FileStream stream = File.Create(path);
		Save(stream);
	}

	public void Save(Stream stream)
	{
		using BinaryWriter writer = new(stream, System.Text.Encoding.UTF8, true);
		writer.Write("LibTorch"u8);
		writer.Write(tensors.Count);
		foreach ((string name, Tensor tensor) in tensors)
		{
			writer.Write(name);
			if (tensor.IsNull)
			{
				writer.Write((sbyte)0);
				writer.Write(false);
				writer.Write((byte)0);
				writer.Write(0);
				writer.Write(0L);
			}
			else
			{
				writer.Write((sbyte)tensor.Type);
				writer.Write(tensor.RequiresGrad);
				writer.Write((byte)tensor.ElementSize());

				long[] lengths = tensor.Sizes();
				writer.Write(lengths.Length);
				foreach (long length in lengths)
				{
					writer.Write(length);
				}
				writer.Write(tensor.Numel());

				tensor.WriteValues(stream);
			}
		}
	}

	private string GetFullName(string name)
	{
		return string.Concat(prefix, name);
	}

	public void Dispose()
	{
		Debug.Assert(string.IsNullOrEmpty(prefix), "Non-root state dictionary should never be disposed.");
		foreach (Tensor tensor in tensors.Values)
		{
			tensor.Dispose();
		}
	}
}
