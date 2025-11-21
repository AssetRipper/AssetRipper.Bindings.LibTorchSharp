namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class ParameterNameChanges
{
	public static string? GetParameterName(string methodName, int index) => (methodName, index) switch
	{
		("JIT_Module_named_attributes", 2) => "allocator1",
		("JIT_Module_named_buffers", 1) => "allocator1",
		("JIT_Module_named_children", 1) => "allocator1",
		("JIT_Module_named_modules", 1) => "allocator1",
		("JIT_Module_named_parameters", 1) => "allocator1",
		("NN_Module_get_parameters", 1) => "allocator",
		_ => null
	};

	public static MethodData ApplyParameterNameChanges(this MethodData method)
	{
		return method with { Parameters = ReplaceParameterNames(method.Name, method.Parameters) };
	}

	private static ParameterDataArray ReplaceParameterNames(string methodName, ParameterDataArray parameters)
	{
		if (parameters.Length == 0)
		{
			return parameters;
		}
		ParameterData[] modifiedParameters = new ParameterData[parameters.Length];
		bool anyChanges = false;
		for (int i = 0; i < parameters.Length; i++)
		{
			string? newName = GetParameterName(methodName, i);
			if (newName is null)
			{
				modifiedParameters[i] = parameters[i];
			}
			else
			{
				anyChanges = true;
				modifiedParameters[i] = parameters[i] with { Name = newName };
			}
		}
		return anyChanges ? new ParameterDataArray(modifiedParameters) : parameters;
	}
}
