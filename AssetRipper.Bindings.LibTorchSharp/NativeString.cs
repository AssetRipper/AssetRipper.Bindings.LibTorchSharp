namespace AssetRipper.Bindings.LibTorchSharp;

internal static class NativeString
{
	// This currently uses UTF-8 encoding, which might not be correct.

	public static ReadOnlySpan<byte> ToNullTerminated(this string str)
	{
		int byteCount = System.Text.Encoding.UTF8.GetByteCount(str);
		byte[] buffer = new byte[byteCount + 1];
		System.Text.Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
		buffer[byteCount] = 0; // Null-terminate
		return buffer;
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
		return System.Text.Encoding.UTF8.GetString((byte*)ptr, length);
	}
}
