namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct StructData(string StructName, string OpaqueName, string PrefixName)
{
	public TypeData StructType => new TypeData(StructName, 0);
	public TypeData OpaqueType => new TypeData(OpaqueName, 1);

	public bool TryReplaceOpaqueType(TypeData type, out TypeData result)
	{
		if (type.Name == OpaqueName && type.PointerLevel >= 1)
		{
			result = new TypeData(StructName, type.PointerLevel - 1);
			return true;
		}
		else if (type.IsFunctionPointer && type.Name.Contains($"{OpaqueName}*"))
		{
			string replacedName = type.Name.Replace($"LowLevel.{OpaqueName}*", StructName);
			result = new TypeData(replacedName, type.PointerLevel);
			return true;
		}
		else
		{
			result = type;
			return false;
		}
	}
}
