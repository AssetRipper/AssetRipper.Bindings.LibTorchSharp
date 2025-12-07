using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly struct ReflectionContext
{
	private sealed record class ReflectionInfo(MethodInfo Method, ParameterInfo[] Parameters);

	private readonly Dictionary<string, ReflectionInfo?> dictionary;

	public ReflectionContext(Dictionary<string, string> methodNameToEntryPoint, ImmutableArray<MethodData> pinvokeMethods)
	{
		Dictionary<string, MethodInfo> entryPointToMethodInfo = GetTorchSharpPInvokeMethods().ToDictionary(GetEntryPoint, m => m);
		dictionary = pinvokeMethods.ToDictionary(m => m.Name, m =>
		{
			string? entryPoint = methodNameToEntryPoint.GetValueOrDefault(m.Name);
			if (entryPoint is null)
			{
				return null;
			}
			MethodInfo? methodInfo = entryPointToMethodInfo.GetValueOrDefault(entryPoint);
			if (methodInfo is null)
			{
				return null;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != m.Parameters.Length)
			{
				return null;
			}
			return new ReflectionInfo(methodInfo, parameters);
		});
	}

	public string? GetReturnType(string methodName) => methodName switch
	{
		"NN_Module_has_parameter" => "bool",
		"Scalar_get_Type" => "ScalarType",
		"Tensor_get_Type" => "ScalarType",
		"Tensor_device_type" => "DeviceType",
		"Tensor_is_contiguous" => "bool",
		_ => GetReturnTypeFromMethodInfo(dictionary.GetValueOrDefault(methodName)?.Method),
	};

	private static string? GetReturnTypeFromMethodInfo(MethodInfo? method)
	{
		if (method is null)
		{
			return null;
		}
		else if (method.ReturnType == typeof(bool))
		{
			return "bool";
		}
		else if (method.ReturnType == typeof(string))
		{
			return "NativeString";
		}
		else
		{
			return null;
		}
	}

	public bool IsOutParameter(string methodName, int parameterIndex, string parameterName)
	{
		return dictionary.GetValueOrDefault(methodName)?.Parameters[parameterIndex].IsOut ?? false;
	}

	public bool IsBooleanParameter(string methodName, int parameterIndex, string parameterName)
	{
		return dictionary.GetValueOrDefault(methodName)?.Parameters[parameterIndex].ParameterType == typeof(bool);
	}

	public bool IsStringParameter(string methodName, int parameterIndex, string parameterName) => (methodName, parameterName) switch
	{
		("NN_Module_get_parameter", "name") => true,
		("NN_Module_has_parameter", "name") => true,
		("NN_Module_register_buffer", "name") => true,
		("NN_Module_register_module", "name") => true,
		("NN_Module_register_parameter", "name") => true,
		_ => dictionary.GetValueOrDefault(methodName)?.Parameters[parameterIndex].ParameterType == typeof(string),
	};

	private static IEnumerable<MethodInfo> GetTorchSharpPInvokeMethods()
	{
		Type pinvokeClass = typeof(TorchSharp.torch).Assembly.GetType("TorchSharp.PInvoke.NativeMethods") ?? throw new InvalidOperationException("Could not find TorchSharp.PInvoke.NativeMethods type.");
		foreach (MethodInfo method in pinvokeClass.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
		{
			if (method.Name == "THSTorch_get_and_reset_last_err")
			{
				continue;
			}
			int parametersLength = method.GetParameters().Length;
			if ((method.Name, parametersLength) is ("THSTensor_var_along_dimensions", 6) or ("THSTensor_to_type", 2) or ("THSTensor_randint", 7))
			{
				// Bug in TorchSharp
				// https://github.com/dotnet/TorchSharp/pull/1508
				continue;
			}
			if (method.GetCustomAttribute<DllImportAttribute>() != null)
			{
				yield return method;
			}
		}
	}

	private static string GetEntryPoint(MethodInfo method)
	{
		return method.GetCustomAttribute<DllImportAttribute>()?.EntryPoint ?? method.Name;
	}
}
