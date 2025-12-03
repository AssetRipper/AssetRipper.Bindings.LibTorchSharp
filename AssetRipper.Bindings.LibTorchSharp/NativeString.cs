using System.Runtime.CompilerServices;
using System.Text;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly ref struct NativeString
{
	private static readonly byte[] _emptyData = [0];

	// This currently uses UTF-8 encoding, which might not be correct.

	private readonly ReadOnlySpan<byte> data;
	private readonly bool hasValue;

	public static NativeString Null => default;

	public bool IsNull => !hasValue;

	public NativeString(ReadOnlySpan<byte> data)
	{
		// Assume data is null-terminated, which is true for u8 strings.
		// We can't guarantee that a u8 string was passed in, but we have no way to check.
		this.data = data;
		hasValue = true;
	}

	public NativeString(Span<byte> data)
	{
		if (data.Length == 0)
		{
			this.data = data;
		}
		else if (data[^1] != 0)
		{
			// Ensure null-termination
			byte[] nullTerminatedData = new byte[data.Length + 1];
			data.CopyTo(nullTerminatedData);
			nullTerminatedData[^1] = 0;
			this.data = nullTerminatedData.AsSpan(0, data.Length);
		}
		else
		{
			this.data = data;
		}
		hasValue = true;
	}

	public NativeString(byte[] data) : this(data.AsSpan())
	{
	}

	public unsafe NativeString(sbyte* ptr)
	{
		if (ptr == null)
		{
			data = [];
			return;
		}
		int length = 0;
		sbyte* c = ptr;
		while (*c != 0)
		{
			length++;
			c++;
		}
		data = new ReadOnlySpan<byte>(ptr, length);
		hasValue = true;
	}

	public NativeString(string? str)
	{
		if (str is not null)
		{
			int byteCount = Encoding.UTF8.GetByteCount(str);
			byte[] buffer = new byte[byteCount + 1];
			Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
			buffer[byteCount] = 0; // Null-terminate
			data = buffer;
			hasValue = true;
		}
	}

	public static implicit operator NativeString(ReadOnlySpan<byte> data) => new(data);
	public static implicit operator NativeString(Span<byte> data) => new(data);
	public static implicit operator NativeString(byte[] data) => new(data);
	public static unsafe implicit operator NativeString(sbyte* ptr) => new(ptr);
	public static explicit operator NativeString(string? str) => new(str);

	public static implicit operator ReadOnlySpan<byte>(NativeString nativeString) => nativeString.data;
	public static explicit operator string?(NativeString nativeString) => nativeString.ToString();

	public readonly ref sbyte GetPinnableReference()
	{
		if (data.Length == 0)
		{
			return ref Unsafe.As<byte, sbyte>(ref _emptyData[0]);
		}
		else
		{
			return ref Unsafe.As<byte, sbyte>(ref Unsafe.AsRef(in data.GetPinnableReference()));
		}
	}

	public static unsafe string FromNullTerminated(sbyte* ptr)
	{
		if (ptr == null)
		{
			return "";
		}
		int length = 0;
		sbyte* c = ptr;
		while (*c != 0)
		{
			length++;
			c++;
		}
		return Encoding.UTF8.GetString((byte*)ptr, length);
	}

	public override string? ToString()
	{
		return hasValue ? Encoding.UTF8.GetString(data) : null;
	}
}
