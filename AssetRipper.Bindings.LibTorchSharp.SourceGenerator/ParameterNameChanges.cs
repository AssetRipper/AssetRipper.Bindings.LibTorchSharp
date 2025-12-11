namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class ParameterNameChanges
{
	private static string? GetParameterName(string methodName, string originalName) => (methodName, originalName) switch
	{
		("JIT_Module_named_attributes", "allocator") => "allocator1",
		("JIT_Module_named_buffers", "allocator") => "allocator1",
		("JIT_Module_named_children", "allocator") => "allocator1",
		("JIT_Module_named_modules", "allocator") => "allocator1",
		("JIT_Module_named_parameters", "allocator") => "allocator1",
		("NN_Module_get_parameters", "allocator1") => "allocator",
		("NN_Module_to_device", "device") => "device_type",
		("NN_Module_to_device", "index") => "device_index",
		("NN_Module_to_device_dtype", "device") => "device_type",
		("NN_Module_to_device_dtype", "index") => "device_index",
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
			string? newName = GetParameterName(methodName, parameters[i].Name);
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
