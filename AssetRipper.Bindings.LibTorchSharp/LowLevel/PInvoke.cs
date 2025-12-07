using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;

public static unsafe partial class PInvoke
{
	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_isGradEnabled", ExactSpelling = true)]
	public static extern bool Autograd_isGradEnabled();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_setGrad", ExactSpelling = true)]
	public static extern void Autograd_set_IsGradEnabled(bool enabled);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_isInferenceModeEnabled", ExactSpelling = true)]
	public static extern bool Autograd_isInferenceModeEnabled();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_getInferenceModeGuard", ExactSpelling = true)]
	[return: NativeTypeName("InferenceMode")]
	public static extern OpaqueInferenceMode* Autograd_getInferenceModeGuard(bool mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_deleteInferenceModeGuard", ExactSpelling = true)]
	public static extern void Autograd_deleteInferenceModeGuard([NativeTypeName("InferenceMode")] OpaqueInferenceMode* ptr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_isAnomalyEnabled", ExactSpelling = true)]
	public static extern bool Autograd_isAnomalyEnabled();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_shouldCheckNaN", ExactSpelling = true)]
	public static extern bool Autograd_shouldCheckNaN();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_setAnomaly", ExactSpelling = true)]
	public static extern void Autograd_setAnomaly(bool enabled, bool check_nan);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_grad", ExactSpelling = true)]
	public static extern void Autograd_grad([NativeTypeName("Tensor *")] OpaqueTensor** outputs, [NativeTypeName("const int64_t")] long oLength, [NativeTypeName("Tensor *")] OpaqueTensor** inputs, [NativeTypeName("const int64_t")] long iLength, [NativeTypeName("Tensor *")] OpaqueTensor** grad_outs, [NativeTypeName("const int64_t")] long gLenght, bool retain_graph, bool create_graph, bool allow_unused, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_backward", ExactSpelling = true)]
	public static extern void Autograd_backward([NativeTypeName("Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int64_t")] long tLength, [NativeTypeName("Tensor *")] OpaqueTensor** grad_tensors, [NativeTypeName("const int64_t")] long gtLength, bool retain_graph, bool create_graph, [NativeTypeName("Tensor *")] OpaqueTensor** inputs, [NativeTypeName("const int64_t")] long iLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_CSharpNode_ctor", ExactSpelling = true)]
	public static extern CSharpNode Autograd_CSharpNode_ctor([NativeTypeName("TensorArray (*)(Tensor *, int)")] delegate* unmanaged[Cdecl]<OpaqueTensor**, int, TensorArray> applyFunc, [NativeTypeName("void (*)()")] delegate* unmanaged[Cdecl]<void> managedDeleteNode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_CSharpNode_disposeSharedPtr", ExactSpelling = true)]
	public static extern void Autograd_CSharpNode_disposeSharedPtr(CSharpNode node);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_CSharpNode_disposeWeakPtr", ExactSpelling = true)]
	public static extern void Autograd_CSharpNode_disposeWeakPtr(CSharpNode node);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_CSharpNode_setNextEdges", ExactSpelling = true)]
	public static extern void Autograd_CSharpNode_setNextEdges(CSharpNode node, TensorArray vars_, bool is_executable);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_CSharpNode_clearInputMetadata", ExactSpelling = true)]
	public static extern void Autograd_CSharpNode_clearInputMetadata(CSharpNode node);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_Function_wrapOutputs", ExactSpelling = true)]
	public static extern void Autograd_Function_wrapOutputs(TensorArray vars_, TensorArray nonDiff_, TensorArray dirty_, TensorArray outputs_, CSharpNode node, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_SavedVariable_ctor", ExactSpelling = true)]
	[return: NativeTypeName("SavedVariable")]
	public static extern OpaqueSavedVariable* Autograd_SavedVariable_ctor([NativeTypeName("Tensor")] OpaqueTensor* variable, CSharpNode node, bool is_inplace_on_view);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_SavedVariable_dispose", ExactSpelling = true)]
	public static extern void Autograd_SavedVariable_dispose([NativeTypeName("SavedVariable")] OpaqueSavedVariable* var);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_SavedVariable_unpack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Autograd_SavedVariable_unpack([NativeTypeName("SavedVariable")] OpaqueSavedVariable* saved_variable, CSharpNode saved_for);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSAutograd_SavedVariable_reset_data", ExactSpelling = true)]
	public static extern void Autograd_SavedVariable_reset_data([NativeTypeName("SavedVariable")] OpaqueSavedVariable* saved_variable);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_load", ExactSpelling = true)]
	[return: NativeTypeName("JITModule")]
	public static extern OpaqueJITModule* JIT_load([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_load_byte_array", ExactSpelling = true)]
	[return: NativeTypeName("JITModule")]
	public static extern OpaqueJITModule* JIT_load_byte_array([NativeTypeName("char *")] sbyte* bytes, [NativeTypeName("int64_t")] long size, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_save", ExactSpelling = true)]
	public static extern void JIT_save([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("const char *")] sbyte* filename);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_save_byte_array", ExactSpelling = true)]
	public static extern void JIT_save_byte_array([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("char *")] sbyte* bytes, [NativeTypeName("int64_t")] long size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_compile", ExactSpelling = true)]
	[return: NativeTypeName("JITCompilationUnit")]
	public static extern OpaqueJITCompilationUnit* JIT_compile([NativeTypeName("const char *")] sbyte* script);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_dispose", ExactSpelling = true)]
	public static extern void JIT_Module_dispose([NativeTypeName("const JITModule")] OpaqueJITModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_CompilationUnit_dispose", ExactSpelling = true)]
	public static extern void JIT_CompilationUnit_dispose([NativeTypeName("const JITCompilationUnit")] OpaqueJITCompilationUnit* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_num_inputs", ExactSpelling = true)]
	public static extern int JIT_Module_num_inputs([NativeTypeName("const JITModule")] OpaqueJITModule* method);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_num_outputs", ExactSpelling = true)]
	public static extern int JIT_Module_num_outputs([NativeTypeName("const JITModule")] OpaqueJITModule* method);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_forward", ExactSpelling = true)]
	public static extern void JIT_Module_forward([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("const TensorOrScalar *")] TensorOrScalar* tensorPtrs, [NativeTypeName("const int")] int length, [NativeTypeName("TensorOrScalar *(*)(int32_t, size_t)")] delegate* unmanaged[Cdecl]<int, nuint, TensorOrScalar*> allocator, [NativeTypeName("int8_t *")] sbyte* typeCode, [NativeTypeName("int32_t")] int idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_invoke", ExactSpelling = true)]
	public static extern void JIT_Module_invoke([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const TensorOrScalar *")] TensorOrScalar* tensorPtrs, [NativeTypeName("const int")] int length, [NativeTypeName("TensorOrScalar *(*)(int32_t, size_t)")] delegate* unmanaged[Cdecl]<int, nuint, TensorOrScalar*> allocator, [NativeTypeName("int8_t *")] sbyte* typeCode, [NativeTypeName("int32_t")] int idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_CompilationUnit_Invoke", ExactSpelling = true)]
	public static extern void JIT_CompilationUnit_Invoke([NativeTypeName("const JITCompilationUnit")] OpaqueJITCompilationUnit* module, [NativeTypeName("const char *")] sbyte* method, [NativeTypeName("const TensorOrScalar *")] TensorOrScalar* tensorPtrs, [NativeTypeName("const int")] int length, [NativeTypeName("TensorOrScalar *(*)(int32_t, size_t)")] delegate* unmanaged[Cdecl]<int, nuint, TensorOrScalar*> allocator, [NativeTypeName("int8_t *")] sbyte* typeCode, [NativeTypeName("int32_t")] int idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_is_training", ExactSpelling = true)]
	public static extern int JIT_Module_is_training([NativeTypeName("JITModule")] OpaqueJITModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_train", ExactSpelling = true)]
	public static extern void JIT_Module_train([NativeTypeName("JITModule")] OpaqueJITModule* module, bool on);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_eval", ExactSpelling = true)]
	public static extern void JIT_Module_eval([NativeTypeName("JITModule")] OpaqueJITModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_to_device_dtype", ExactSpelling = true)]
	public static extern void JIT_Module_to_device_dtype([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("int8_t")] sbyte dtype, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_to_device", ExactSpelling = true)]
	public static extern void JIT_Module_to_device([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_to_dtype", ExactSpelling = true)]
	public static extern void JIT_Module_to_dtype([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_getInputType", ExactSpelling = true)]
	[return: NativeTypeName("JITType")]
	public static extern OpaqueJITType* JIT_Module_getInputType([NativeTypeName("JITModule")] OpaqueJITModule* module, [NativeTypeName("int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Type_kind", ExactSpelling = true)]
	[return: NativeTypeName("int8_t")]
	public static extern sbyte JIT_Type_kind([NativeTypeName("JITType")] OpaqueJITType* handle);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Type_cast", ExactSpelling = true)]
	public static extern void* JIT_Type_cast([NativeTypeName("const JITType")] OpaqueJITType* type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_TensorType_dtype", ExactSpelling = true)]
	[return: NativeTypeName("int8_t")]
	public static extern sbyte JIT_TensorType_dtype([NativeTypeName("const JITTensorType")] OpaqueJITTensorType* type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_TensorType_sizes", ExactSpelling = true)]
	public static extern void JIT_TensorType_sizes([NativeTypeName("const JITTensorType")] OpaqueJITTensorType* type, [NativeTypeName("int64_t *(*)(int64_t)")] delegate* unmanaged[Cdecl]<long, long*> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Type_dispose", ExactSpelling = true)]
	public static extern void JIT_Type_dispose([NativeTypeName("const JITType")] OpaqueJITType* type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_TensorType_dispose", ExactSpelling = true)]
	public static extern void JIT_TensorType_dispose([NativeTypeName("const JITTensorType")] OpaqueJITTensorType* type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_modules", ExactSpelling = true)]
	public static extern void JIT_Module_modules([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("JITModule *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueJITModule**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_named_modules", ExactSpelling = true)]
	public static extern void JIT_Module_named_modules([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("JITModule *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueJITModule**> allocator, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_named_children", ExactSpelling = true)]
	public static extern void JIT_Module_named_children([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("JITModule *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueJITModule**> allocator, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_get_method", ExactSpelling = true)]
	[return: NativeTypeName("JITMethod")]
	public static extern OpaqueJITMethod* JIT_Module_get_method([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("const char *")] sbyte* name);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_parameters", ExactSpelling = true)]
	public static extern void JIT_Module_parameters([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_named_parameters", ExactSpelling = true)]
	public static extern void JIT_Module_named_parameters([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_named_buffers", ExactSpelling = true)]
	public static extern void JIT_Module_named_buffers([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_named_attributes", ExactSpelling = true)]
	public static extern void JIT_Module_named_attributes([NativeTypeName("const JITModule")] OpaqueJITModule* module, bool recurse, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Module_set_attribute", ExactSpelling = true)]
	public static extern void JIT_Module_set_attribute([NativeTypeName("const JITModule")] OpaqueJITModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Method_num_inputs", ExactSpelling = true)]
	public static extern int JIT_Method_num_inputs([NativeTypeName("const JITMethod")] OpaqueJITMethod* method);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Method_dispose", ExactSpelling = true)]
	public static extern void JIT_Method_dispose([NativeTypeName("const JITMethod")] OpaqueJITMethod* method);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_Method_name", ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* JIT_Method_name([NativeTypeName("const JITMethod")] OpaqueJITMethod* method);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_AllocateTensorOrScalarArray", ExactSpelling = true)]
	public static extern TensorOrScalar* JIT_AllocateTensorOrScalarArray([NativeTypeName("int32_t")] int size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_FreeTensorOrScalarArray", ExactSpelling = true)]
	public static extern void JIT_FreeTensorOrScalarArray(TensorOrScalar* ptr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_SetTensorOrScalar", ExactSpelling = true)]
	public static extern void JIT_SetTensorOrScalar(TensorOrScalar* array, [NativeTypeName("int32_t")] int index, [NativeTypeName("int64_t")] long type_code, [NativeTypeName("int64_t")] long array_index, [NativeTypeName("ptrdiff_t")] nint handle);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSJIT_GetTensorOrScalar", ExactSpelling = true)]
	public static extern TensorOrScalar* JIT_GetTensorOrScalar(TensorOrScalar* array, [NativeTypeName("int32_t")] int index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_has_parameter", ExactSpelling = true)]
	public static extern int NN_Module_has_parameter([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_parameter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Module_get_parameter([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_named_parameters", ExactSpelling = true)]
	public static extern void NN_Module_get_named_parameters([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator1, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_named_buffers", ExactSpelling = true)]
	public static extern void NN_Module_get_named_buffers([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator1, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_named_children", ExactSpelling = true)]
	public static extern void NN_Module_get_named_children([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("NNModule *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueNNModule**> allocator1, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_named_modules", ExactSpelling = true)]
	public static extern void NN_Module_get_named_modules([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("NNModule *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueNNModule**> allocator1, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_get_parameters", ExactSpelling = true)]
	public static extern void NN_Module_get_parameters([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator1, bool recurse);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_is_training", ExactSpelling = true)]
	public static extern int NN_Module_get_IsTraining([NativeTypeName("NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_train", ExactSpelling = true)]
	public static extern void NN_Module_set_IsTraining([NativeTypeName("NNModule")] OpaqueNNModule* module, bool on);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_children_size", ExactSpelling = true)]
	[return: NativeTypeName("long")]
	public static extern int NN_Module_children_size([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_child", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Module_child([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const int")] int index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_name", ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* NN_Module_name([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_zero_grad", ExactSpelling = true)]
	public static extern void NN_Module_zero_grad([NativeTypeName("const NNModule")] OpaqueNNModule* module, bool set_to_none);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_save", ExactSpelling = true)]
	public static extern void NN_Module_save([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* location);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_load", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Module_load([NativeTypeName("const char *")] sbyte* location);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_register_buffer", ExactSpelling = true)]
	public static extern void NN_Module_register_buffer([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const Tensor")] OpaqueTensor* submodule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_register_parameter", ExactSpelling = true)]
	public static extern void NN_Module_register_parameter([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_register_module", ExactSpelling = true)]
	public static extern void NN_Module_register_module([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const NNModule")] OpaqueNNModule* submodule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_dispose", ExactSpelling = true)]
	public static extern void NN_Module_dispose([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_to_device", ExactSpelling = true)]
	public static extern void NN_Module_to_device([NativeTypeName("NNModule")] OpaqueNNModule* module, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_to_dtype", ExactSpelling = true)]
	public static extern void NN_Module_to_dtype([NativeTypeName("NNModule")] OpaqueNNModule* module, [NativeTypeName("int8_t")] sbyte dtype, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Module_to_device_dtype", ExactSpelling = true)]
	public static extern void NN_Module_to_device_dtype([NativeTypeName("NNModule")] OpaqueNNModule* module, [NativeTypeName("int8_t")] sbyte dtype, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_AnyModule_dispose", ExactSpelling = true)]
	public static extern void NN_AnyModule_dispose([NativeTypeName("const NNAnyModule")] OpaqueNNAnyModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_custom_module", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_CustomModule_ctor([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("Tensor (*)(Tensor)")] delegate* unmanaged[Cdecl]<OpaqueTensor*, OpaqueTensor*> forward, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_normalize", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_normalize([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_batch_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_batch_norm([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* running_mean, [NativeTypeName("const Tensor")] OpaqueTensor* running_var, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const bool")] bool training, [NativeTypeName("const double")] double momentum, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_group_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_group_norm([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("int64_t")] long num_groups, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_instance_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_instance_norm([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* running_mean, [NativeTypeName("const Tensor")] OpaqueTensor* running_var, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const bool")] bool use_input_stats, [NativeTypeName("const double")] double momentum, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_layer_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_layer_norm([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t *")] long* normalized_shape, [NativeTypeName("const int64_t")] long normalized_shape_len, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_local_response_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_local_response_norm([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long size, [NativeTypeName("const double")] double alpha, [NativeTypeName("const double")] double beta, [NativeTypeName("const double")] double k);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_dropout", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_dropout([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, bool training, bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_dropout2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_dropout2d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, bool training, bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_dropout3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_dropout3d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, bool training, bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_alpha_dropout", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_alpha_dropout([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, bool training, bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_feature_alpha_dropout", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_feature_alpha_dropout([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const double")] double p, bool training, bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_fold", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_fold([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long out1, [NativeTypeName("const int64_t")] long out2, [NativeTypeName("const int64_t")] long kernel1, [NativeTypeName("const int64_t")] long kernel2, [NativeTypeName("const int64_t")] long stride1, [NativeTypeName("const int64_t")] long stride2, [NativeTypeName("const int64_t")] long pad1, [NativeTypeName("const int64_t")] long pad2, [NativeTypeName("const int64_t")] long dil1, [NativeTypeName("const int64_t")] long dil2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_unfold", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_unfold([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long kernel1, [NativeTypeName("const int64_t")] long kernel2, [NativeTypeName("const int64_t")] long stride1, [NativeTypeName("const int64_t")] long stride2, [NativeTypeName("const int64_t")] long pad1, [NativeTypeName("const int64_t")] long pad2, [NativeTypeName("const int64_t")] long dil1, [NativeTypeName("const int64_t")] long dil2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_functional_linear", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_linear([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weights, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_functional_bilinear", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_bilinear([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("const Tensor")] OpaqueTensor* weights, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pixel_shuffle", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_pixel_shuffle([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long upscale_factor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pixel_unshuffle", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_pixel_unshuffle([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long downscale_fasctor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pad", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_pad([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t *")] long* pad, [NativeTypeName("const int")] int pad_length, [NativeTypeName("const int8_t")] sbyte mode, [NativeTypeName("const double")] double value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_interpolate", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_interpolate([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t *")] long* size, [NativeTypeName("const int")] int size_len, [NativeTypeName("const double *")] double* scale_factor, [NativeTypeName("const int")] int scale_factor_len, [NativeTypeName("const int8_t")] sbyte mode, [NativeTypeName("const int8_t")] sbyte align_corners, [NativeTypeName("const bool")] bool recompute_scale_factor, [NativeTypeName("const bool")] bool antialias, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_grid_sample", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_grid_sample([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* grid, [NativeTypeName("const int8_t")] sbyte mode, [NativeTypeName("const int8_t")] sbyte padding_mode, [NativeTypeName("const int8_t")] sbyte align_corners);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_affine_grid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_affine_grid([NativeTypeName("const Tensor")] OpaqueTensor* theta, [NativeTypeName("const int64_t *")] long* size, [NativeTypeName("const int")] int size_len, [NativeTypeName("const bool")] bool align_corners);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Embedding_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Embedding_ctor([NativeTypeName("const int64_t")] long num_embeddings, [NativeTypeName("const int64_t")] long embedding_dims, [NativeTypeName("const int64_t")] long padding_idx, bool has_pi, [NativeTypeName("const double")] double max_norm, [NativeTypeName("const bool")] bool has_mn, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const bool")] bool scale_grad_by_freq, [NativeTypeName("const bool")] bool sparse, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Embedding_from_pretrained", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Embedding_from_pretrained([NativeTypeName("const Tensor")] OpaqueTensor* embeddings, [NativeTypeName("const bool")] bool freeze, [NativeTypeName("const int64_t")] long padding_idx, bool has_pi, [NativeTypeName("const double")] double max_norm, [NativeTypeName("const bool")] bool has_mn, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const bool")] bool scale_grad_by_freq, [NativeTypeName("const bool")] bool sparse, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Embedding_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Embedding_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weights);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Embedding_weight", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Embedding_weight([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Embedding_set_weight", ExactSpelling = true)]
	public static extern void NN_Embedding_set_weight([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weights);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_EmbeddingBag_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_EmbeddingBag_ctor([NativeTypeName("const int64_t")] long num_embeddings, [NativeTypeName("const int64_t")] long embedding_dims, [NativeTypeName("const double")] double max_norm, [NativeTypeName("const bool")] bool has_mn, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const bool")] bool scale_grad_by_freq, [NativeTypeName("const int64_t")] long mode, [NativeTypeName("const bool")] bool sparse, [NativeTypeName("const bool")] bool include_last_offset, [NativeTypeName("const int64_t")] long padding_idx, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_EmbeddingBag_from_pretrained", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_EmbeddingBag_from_pretrained([NativeTypeName("const Tensor")] OpaqueTensor* embeddings, [NativeTypeName("const bool")] bool freeze, [NativeTypeName("const double")] double max_norm, [NativeTypeName("const bool")] bool has_mn, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const bool")] bool scale_grad_by_freq, [NativeTypeName("const int64_t")] long mode, [NativeTypeName("const bool")] bool sparse, [NativeTypeName("const bool")] bool include_last_offset, [NativeTypeName("const int64_t")] long padding_idx, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_EmbeddingBag_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_EmbeddingBag_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* offsets, [NativeTypeName("const Tensor")] OpaqueTensor* per_sample_weights);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_EmbeddingBag_weight", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_EmbeddingBag_weight([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_EmbeddingBag_set_weight", ExactSpelling = true)]
	public static extern void NN_EmbeddingBag_set_weight([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weights);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Transformer_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Transformer_ctor([NativeTypeName("const int64_t")] long d_model, [NativeTypeName("const int64_t")] long nhead, [NativeTypeName("const int64_t")] long num_encoder_layers, [NativeTypeName("const int64_t")] long num_decoder_layers, [NativeTypeName("const int64_t")] long dim_feedforward, [NativeTypeName("const double")] double dropout, [NativeTypeName("const int64_t")] long activation, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Transformer_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Transformer_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* src, [NativeTypeName("const Tensor")] OpaqueTensor* tgt, [NativeTypeName("const Tensor")] OpaqueTensor* src_mask, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_mask, [NativeTypeName("const Tensor")] OpaqueTensor* src_key_padding_mask, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_key_padding_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_key_padding_mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerEncoderLayer_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_TransformerEncoderLayer_ctor([NativeTypeName("const int64_t")] long d_model, [NativeTypeName("const int64_t")] long nhead, [NativeTypeName("const int64_t")] long dim_feedforward, [NativeTypeName("const double")] double dropout, [NativeTypeName("const int64_t")] long activation, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerEncoderLayer_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_TransformerEncoderLayer_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* src, [NativeTypeName("const Tensor")] OpaqueTensor* src_mask, [NativeTypeName("const Tensor")] OpaqueTensor* src_key_padding_mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerDecoderLayer_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_TransformerDecoderLayer_ctor([NativeTypeName("const int64_t")] long d_model, [NativeTypeName("const int64_t")] long nhead, [NativeTypeName("const int64_t")] long dim_feedforward, [NativeTypeName("const double")] double dropout, [NativeTypeName("const int64_t")] long activation, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerDecoderLayer_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_TransformerDecoderLayer_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* tgt, [NativeTypeName("const Tensor")] OpaqueTensor* memory, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_mask, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_key_padding_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_key_padding_mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerEncoder_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_TransformerEncoder_ctor([NativeTypeName("const NNModule")] OpaqueNNModule* encoder_layer, [NativeTypeName("const int64_t")] long num_layers, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerEncoder_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_TransformerEncoder_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* src, [NativeTypeName("const Tensor")] OpaqueTensor* src_mask, [NativeTypeName("const Tensor")] OpaqueTensor* src_key_padding_mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerDecoder_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_TransformerDecoder_ctor([NativeTypeName("const NNModule")] OpaqueNNModule* decoder_layer, [NativeTypeName("const int64_t")] long num_layers, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_TransformerDecoder_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_TransformerDecoder_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* tgt, [NativeTypeName("const Tensor")] OpaqueTensor* memory, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_mask, [NativeTypeName("const Tensor")] OpaqueTensor* tgt_key_padding_mask, [NativeTypeName("const Tensor")] OpaqueTensor* memory_key_padding_mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_MultiheadAttention_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_MultiheadAttention_ctor([NativeTypeName("const int64_t")] long embeded_dim, [NativeTypeName("const int64_t")] long num_heads, [NativeTypeName("const double")] double dropout, [NativeTypeName("const bool")] bool bias, [NativeTypeName("const bool")] bool add_bias_kv, [NativeTypeName("const bool")] bool add_zero_attn, [NativeTypeName("const int64_t")] long kdim, [NativeTypeName("const int64_t")] long vdim, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_MultiheadAttention_forward", ExactSpelling = true)]
	public static extern void NN_MultiheadAttention_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* query, [NativeTypeName("const Tensor")] OpaqueTensor* key, [NativeTypeName("const Tensor")] OpaqueTensor* value, [NativeTypeName("const Tensor")] OpaqueTensor* key_padding_mask, [NativeTypeName("const bool")] bool need_weights, [NativeTypeName("const Tensor")] OpaqueTensor* attn_mask, [NativeTypeName("Tensor &")] OpaqueTensor** res1, [NativeTypeName("Tensor &")] OpaqueTensor** res2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_RNN_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const int64_t")] long num_layers, [NativeTypeName("const int64_t")] long nonlinearity, [NativeTypeName("const bool")] bool bias, [NativeTypeName("const bool")] bool batchFirst, [NativeTypeName("const double")] double dropout, [NativeTypeName("const bool")] bool bidirectional, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNN_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("Tensor *")] OpaqueTensor** h_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_forward_with_packed_input", ExactSpelling = true)]
	[return: NativeTypeName("PackedSequence")]
	public static extern OpaquePackedSequence* NN_RNN_forward_with_packed_input([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const PackedSequence")] OpaquePackedSequence* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("Tensor *")] OpaqueTensor** h_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRU_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_GRU_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const int64_t")] long num_layers, [NativeTypeName("const bool")] bool bias, [NativeTypeName("const bool")] bool batchFirst, [NativeTypeName("const double")] double dropout, [NativeTypeName("const bool")] bool bidirectional, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRU_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRU_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("Tensor *")] OpaqueTensor** h_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRU_forward_with_packed_input", ExactSpelling = true)]
	[return: NativeTypeName("PackedSequence")]
	public static extern OpaquePackedSequence* NN_GRU_forward_with_packed_input([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const PackedSequence")] OpaquePackedSequence* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("Tensor *")] OpaqueTensor** h_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTM_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_LSTM_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const int64_t")] long num_layers, [NativeTypeName("const bool")] bool bias, [NativeTypeName("const bool")] bool batchFirst, [NativeTypeName("const double")] double dropout, [NativeTypeName("const bool")] bool bidirectional, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTM_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTM_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* h0, [NativeTypeName("const Tensor")] OpaqueTensor* c0, [NativeTypeName("Tensor *")] OpaqueTensor** h_n, [NativeTypeName("Tensor *")] OpaqueTensor** c_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTM_forward_with_packed_input", ExactSpelling = true)]
	[return: NativeTypeName("PackedSequence")]
	public static extern OpaquePackedSequence* NN_LSTM_forward_with_packed_input([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const PackedSequence")] OpaquePackedSequence* input1, [NativeTypeName("const Tensor")] OpaqueTensor* h0, [NativeTypeName("const Tensor")] OpaqueTensor* c0, [NativeTypeName("Tensor *")] OpaqueTensor** h_n, [NativeTypeName("Tensor *")] OpaqueTensor** c_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_RNNCell_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const int64_t")] long nonlinearity, [NativeTypeName("const bool")] bool bias, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNNCell_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* h0);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_GRUCell_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const bool")] bool bias, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRUCell_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* h0);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_LSTMCell_ctor([NativeTypeName("const int64_t")] long input_size, [NativeTypeName("const int64_t")] long hidden_size, [NativeTypeName("const bool")] bool bias, [NativeTypeName("NNAnyModule *")] OpaqueNNAnyModule** outAsAnyModule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTMCell_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* h0, [NativeTypeName("const Tensor")] OpaqueTensor* c0, [NativeTypeName("Tensor *")] OpaqueTensor** c_n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_flatten_parameters", ExactSpelling = true)]
	public static extern void NN_RNN_flatten_parameters([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRU_flatten_parameters", ExactSpelling = true)]
	public static extern void NN_GRU_flatten_parameters([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTM_flatten_parameters", ExactSpelling = true)]
	public static extern void NN_LSTM_flatten_parameters([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_bias_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNN_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_set_bias_ih", ExactSpelling = true)]
	public static extern void NN_RNN_set_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_weight_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNN_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_set_weight_ih", ExactSpelling = true)]
	public static extern void NN_RNN_set_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_bias_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNN_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_set_bias_hh", ExactSpelling = true)]
	public static extern void NN_RNN_set_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_weight_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNN_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNN_set_weight_hh", ExactSpelling = true)]
	public static extern void NN_RNN_set_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long idx);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_bias_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNNCell_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_set_bias_ih", ExactSpelling = true)]
	public static extern void NN_RNNCell_set_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_weight_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNNCell_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_set_weight_ih", ExactSpelling = true)]
	public static extern void NN_RNNCell_set_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_bias_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNNCell_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_set_bias_hh", ExactSpelling = true)]
	public static extern void NN_RNNCell_set_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_weight_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_RNNCell_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RNNCell_set_weight_hh", ExactSpelling = true)]
	public static extern void NN_RNNCell_set_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_bias_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTMCell_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_set_bias_ih", ExactSpelling = true)]
	public static extern void NN_LSTMCell_set_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_weight_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTMCell_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_set_weight_ih", ExactSpelling = true)]
	public static extern void NN_LSTMCell_set_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_bias_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTMCell_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_set_bias_hh", ExactSpelling = true)]
	public static extern void NN_LSTMCell_set_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_weight_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_LSTMCell_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LSTMCell_set_weight_hh", ExactSpelling = true)]
	public static extern void NN_LSTMCell_set_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_bias_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRUCell_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_set_bias_ih", ExactSpelling = true)]
	public static extern void NN_GRUCell_set_bias_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_weight_ih", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRUCell_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_set_weight_ih", ExactSpelling = true)]
	public static extern void NN_GRUCell_set_weight_ih([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_bias_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRUCell_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_set_bias_hh", ExactSpelling = true)]
	public static extern void NN_GRUCell_set_bias_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* bias);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_weight_hh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_GRUCell_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_GRUCell_set_weight_hh", ExactSpelling = true)]
	public static extern void NN_GRUCell_set_weight_hh([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Sequential_ctor", ExactSpelling = true)]
	[return: NativeTypeName("NNModule")]
	public static extern OpaqueNNModule* NN_Sequential_ctor();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Sequential_push_back", ExactSpelling = true)]
	public static extern void NN_Sequential_push_back([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const NNAnyModule")] OpaqueNNAnyModule* submodule);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Sequential_forward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Sequential_forward([NativeTypeName("const NNModule")] OpaqueNNModule* module, [NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_binary_cross_entropy", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_binary_cross_entropy([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_binary_cross_entropy_with_logits", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_binary_cross_entropy_with_logits([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long reduction, [NativeTypeName("const Tensor")] OpaqueTensor* pos_weights_);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_cosine_embedding_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_cosine_embedding_loss([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const double")] double margin, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_cross_entropy", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_cross_entropy([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long ignore_index, [NativeTypeName("const bool")] bool has_ii, [NativeTypeName("const int64_t")] long reduction, [NativeTypeName("const double")] double smoothing);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_ctc_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_ctc_loss([NativeTypeName("const Tensor")] OpaqueTensor* log_probs, [NativeTypeName("const Tensor")] OpaqueTensor* targets, [NativeTypeName("const Tensor")] OpaqueTensor* input_lengths, [NativeTypeName("const Tensor")] OpaqueTensor* target_lengths, [NativeTypeName("int64_t")] long blank, bool zero_infinity, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_hinge_embedding_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_hinge_embedding_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const double")] double margin, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_huber_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_huber_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const double")] double delta, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_l1_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_l1_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_margin_ranking_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_margin_ranking_loss([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const double")] double margin, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_mse_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_mse_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_multilabel_margin_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_multilabel_margin_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_multilabel_soft_margin_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_multilabel_soft_margin_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_multi_margin_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_multi_margin_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long p, [NativeTypeName("const double")] double margin, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_nll_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_nll_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_poisson_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_poisson_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const bool")] bool logInput, [NativeTypeName("const bool")] bool full, [NativeTypeName("const double")] double eps, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_kl_div_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_kl_div_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction, [NativeTypeName("const bool")] bool log_target);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_smooth_l1_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_smooth_l1_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction, [NativeTypeName("const double")] double beta);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_soft_margin_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_soft_margin_loss([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_triplet_margin_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_triplet_margin_loss([NativeTypeName("const Tensor")] OpaqueTensor* anchor, [NativeTypeName("const Tensor")] OpaqueTensor* positive, [NativeTypeName("const Tensor")] OpaqueTensor* negative, double margin, [NativeTypeName("int64_t")] long p, double eps, bool swap, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_triplet_margin_with_distance_loss", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_triplet_margin_with_distance_loss([NativeTypeName("const Tensor")] OpaqueTensor* anchor, [NativeTypeName("const Tensor")] OpaqueTensor* positive, [NativeTypeName("const Tensor")] OpaqueTensor* negative, [NativeTypeName("Tensor (*)(const Tensor, const Tensor)")] delegate* unmanaged[Cdecl]<OpaqueTensor*, OpaqueTensor*, OpaqueTensor*> distance_function, double margin, bool swap, [NativeTypeName("const int64_t")] long reduction);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Adagrad_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_Adagrad_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int len, [NativeTypeName("const double")] double learning_rate, [NativeTypeName("const double")] double lr_decay, [NativeTypeName("const double")] double weight_decay, [NativeTypeName("const double")] double initial_accumulator_value, [NativeTypeName("const double")] double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Adam_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_Adam_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int len, [NativeTypeName("const double")] double learning_rate, [NativeTypeName("const double")] double beta1, [NativeTypeName("const double")] double beta2, [NativeTypeName("const double")] double eps, [NativeTypeName("const double")] double weight_decay, [NativeTypeName("const bool")] bool amsgrad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_AdamW_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_AdamW_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int len, [NativeTypeName("const double")] double learning_rate, [NativeTypeName("const double")] double beta1, [NativeTypeName("const double")] double beta2, [NativeTypeName("const double")] double eps, [NativeTypeName("const double")] double weight_decay, [NativeTypeName("const bool")] bool amsgrad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LBFGS_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_LBFGS_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int len, [NativeTypeName("const double")] double lr, [NativeTypeName("const int64_t")] long max_iter, [NativeTypeName("const int64_t")] long max_eval, [NativeTypeName("const double")] double tolerange_grad, [NativeTypeName("const double")] double tolerance_change, [NativeTypeName("const int64_t")] long history_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RMSprop_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_RMSprop_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int length, [NativeTypeName("const double")] double learning_rate, [NativeTypeName("const double")] double alpha, [NativeTypeName("const double")] double eps, [NativeTypeName("const double")] double weight_decay, [NativeTypeName("const double")] double momentum, [NativeTypeName("const bool")] bool centered);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_SGD_ctor", ExactSpelling = true)]
	[return: NativeTypeName("Optimizer")]
	public static extern OpaqueOptimizer* NN_SGD_ctor([NativeTypeName("const Tensor *")] OpaqueTensor** parameters, [NativeTypeName("const int")] int length, [NativeTypeName("const double")] double learning_rate, [NativeTypeName("const double")] double momentum, [NativeTypeName("const double")] double dampening, [NativeTypeName("const double")] double weight_decay, [NativeTypeName("const bool")] bool nesterov);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Adam_set_betas", ExactSpelling = true)]
	public static extern void NN_Adam_set_betas([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, double beta1, double beta2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_AdamW_set_betas", ExactSpelling = true)]
	public static extern void NN_AdamW_set_betas([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, double beta1, double beta2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RMSprop_set_momentum", ExactSpelling = true)]
	public static extern void NN_RMSprop_set_momentum([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, double momentum);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_SGD_set_momentum", ExactSpelling = true)]
	public static extern void NN_SGD_set_momentum([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, double momentum);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Optimizer_zero_grad", ExactSpelling = true)]
	public static extern void NN_Optimizer_zero_grad([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Optimizer_getParameters", ExactSpelling = true)]
	public static extern void NN_Optimizer_getParameters([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Optimizer_step", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_Optimizer_step([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("Tensor (*)()")] delegate* unmanaged[Cdecl]<OpaqueTensor*> loss_closure);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Optimizer_dispose", ExactSpelling = true)]
	public static extern void NN_Optimizer_dispose([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Adagrad_set_lr", ExactSpelling = true)]
	public static extern void NN_Adagrad_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_Adam_set_lr", ExactSpelling = true)]
	public static extern void NN_Adam_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_AdamW_set_lr", ExactSpelling = true)]
	public static extern void NN_AdamW_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_LBFGS_set_lr", ExactSpelling = true)]
	public static extern void NN_LBFGS_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_RMSprop_set_lr", ExactSpelling = true)]
	public static extern void NN_RMSprop_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_SGD_set_lr", ExactSpelling = true)]
	public static extern void NN_SGD_set_lr([NativeTypeName("const Optimizer")] OpaqueOptimizer* optimizer, [NativeTypeName("const double")] double lr);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_one_hot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_one_hot([NativeTypeName("const Tensor")] OpaqueTensor* self, [NativeTypeName("const int64_t")] long num_classes);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_cosine_similarity", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_cosine_similarity([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("int64_t")] long dim, double eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pairwise_distance", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_pairwise_distance([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, double p, double eps, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_scaled_dot_product_attention", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_scaled_dot_product_attention([NativeTypeName("const Tensor")] OpaqueTensor* query, [NativeTypeName("const Tensor")] OpaqueTensor* key, [NativeTypeName("const Tensor")] OpaqueTensor* value, [NativeTypeName("const Tensor")] OpaqueTensor* attention_mask, double p, bool casual);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_initUniform", ExactSpelling = true)]
	public static extern void NN_initUniform([NativeTypeName("Tensor")] OpaqueTensor* twrapper, double low, double high);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_initKaimingUniform", ExactSpelling = true)]
	public static extern void NN_initKaimingUniform([NativeTypeName("Tensor")] OpaqueTensor* tensor, double a);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_PackedSequence_data", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_PackedSequence_data([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_PackedSequence_batch_sizes", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_PackedSequence_batch_sizes([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_PackedSequence_sorted_indices", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_PackedSequence_sorted_indices([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_PackedSequence_unsorted_indices", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_PackedSequence_unsorted_indices([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_PackedSequence_dispose", ExactSpelling = true)]
	public static extern void NN_PackedSequence_dispose([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pack_padded_sequence", ExactSpelling = true)]
	[return: NativeTypeName("PackedSequence")]
	public static extern OpaquePackedSequence* NN_pack_padded_sequence([NativeTypeName("Tensor")] OpaqueTensor* input, [NativeTypeName("Tensor")] OpaqueTensor* lengths, bool batch_first, bool enforce_sorted);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pad_packed_sequence", ExactSpelling = true)]
	public static extern void NN_pad_packed_sequence([NativeTypeName("PackedSequence")] OpaquePackedSequence* sequence, bool batch_first, double padding_value, [NativeTypeName("int64_t")] long total_length, [NativeTypeName("Tensor *")] OpaqueTensor** res1, [NativeTypeName("Tensor *")] OpaqueTensor** res2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pad_sequence", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* NN_pad_sequence([NativeTypeName("const Tensor *")] OpaqueTensor** sequences, [NativeTypeName("const int")] int sequences_len, bool batch_first, double padding_value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSNN_pack_sequence", ExactSpelling = true)]
	[return: NativeTypeName("PackedSequence")]
	public static extern OpaquePackedSequence* NN_pack_sequence([NativeTypeName("const Tensor *")] OpaqueTensor** sequences, int sequences_len, bool enforce_sorted);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_storage_offset", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_storage_offset([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSStorage_nbytes", ExactSpelling = true)]
	[return: NativeTypeName("size_t")]
	public static extern nuint Storage_nbytes([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSStorage_set_nbytes", ExactSpelling = true)]
	public static extern void Storage_set_nbytes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("size_t")] nuint nbytes);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSStorage_data_ptr", ExactSpelling = true)]
	public static extern void* Storage_data_ptr([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_abs", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_abs([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_abs_", ExactSpelling = true)]
	public static extern void Tensor_abs_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_acos", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_acos([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_acos_", ExactSpelling = true)]
	public static extern void Tensor_acos_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_avg_pool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_avg_pool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_avg_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_avg_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_avg_pool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_avg_pool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_avg_pool3d_backward_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_avg_pool3d_backward_out([NativeTypeName("const Tensor")] OpaqueTensor* grad_input, [NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_max_pool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_max_pool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_max_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_max_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adaptive_max_pool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adaptive_max_pool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fractional_max_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fractional_max_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const double *")] double* outputRatio, [NativeTypeName("const int")] int outputRatioLength, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fractional_max_pool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fractional_max_pool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const double *")] double* outputRatio, [NativeTypeName("const int")] int outputRatioLength, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lp_pool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lp_pool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const bool")] bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lp_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lp_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double norm_type, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const bool")] bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_add", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_add([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_add_", ExactSpelling = true)]
	public static extern void Tensor_add_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_add_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_add_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_add_scalar_", ExactSpelling = true)]
	public static extern void Tensor_add_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addbmm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addbmm([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* batch1, [NativeTypeName("const Tensor")] OpaqueTensor* batch2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addbmm_", ExactSpelling = true)]
	public static extern void Tensor_addbmm_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* batch1, [NativeTypeName("const Tensor")] OpaqueTensor* batch2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addcdiv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addcdiv([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* tensor1, [NativeTypeName("const Tensor")] OpaqueTensor* tensor2, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addcdiv_", ExactSpelling = true)]
	public static extern void Tensor_addcdiv_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* tensor1, [NativeTypeName("const Tensor")] OpaqueTensor* tensor2, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addcmul", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addcmul([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* tensor1, [NativeTypeName("const Tensor")] OpaqueTensor* tensor2, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addcmul_", ExactSpelling = true)]
	public static extern void Tensor_addcmul_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* tensor1, [NativeTypeName("const Tensor")] OpaqueTensor* tensor2, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addmm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addmm([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* mat2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addmm_", ExactSpelling = true)]
	public static extern void Tensor_addmm_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* mat2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addmv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addmv([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* vec2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addmv_", ExactSpelling = true)]
	public static extern void Tensor_addmv_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* vec2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_addr([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* vec2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_addr_", ExactSpelling = true)]
	public static extern void Tensor_addr_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* mat1, [NativeTypeName("const Tensor")] OpaqueTensor* vec2, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_adjoint", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_adjoint([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_alias", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_alias([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_allclose", ExactSpelling = true)]
	public static extern int Tensor_allclose([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right, double rtol, double atol, bool equal_nan);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_all", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_all([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_all_along_dimension", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_all_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_amax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_amax([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_amax_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_amax_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_amin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_amin([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_amin_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_amin_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_aminmax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_aminmax([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool keepdim, [NativeTypeName("Tensor *")] OpaqueTensor** max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_any", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_any([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_any_along_dimension", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_any_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_angle", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_angle([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arange", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_arange([NativeTypeName("const Scalar")] OpaqueScalar* start, [NativeTypeName("const Scalar")] OpaqueScalar* end, [NativeTypeName("const Scalar")] OpaqueScalar* step, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arange_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_arange_out([NativeTypeName("const Scalar")] OpaqueScalar* start, [NativeTypeName("const Scalar")] OpaqueScalar* end, [NativeTypeName("const Scalar")] OpaqueScalar* step, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arccosh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_arccosh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arccosh_", ExactSpelling = true)]
	public static extern void Tensor_arccosh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arcsinh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_arcsinh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arcsinh_", ExactSpelling = true)]
	public static extern void Tensor_arcsinh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arctanh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_arctanh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_arctanh_", ExactSpelling = true)]
	public static extern void Tensor_arctanh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argmax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argmax([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argmax_along_dimension", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argmax_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argmin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argmin([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argmin_along_dimension", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argmin_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argsort", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argsort([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool descending);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_argwhere", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_argwhere([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_asin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_asin([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_asin_", ExactSpelling = true)]
	public static extern void Tensor_asin_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atan", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_atan([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atan_", ExactSpelling = true)]
	public static extern void Tensor_atan_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atan2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_atan2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atan2_", ExactSpelling = true)]
	public static extern void Tensor_atan2_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atleast_1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_atleast_1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atleast_2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_atleast_2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_atleast_3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_atleast_3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_avg_pool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_avg_pool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, bool ceil_mode, bool count_include_pad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_avg_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_avg_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, bool ceil_mode, bool count_include_pad, [NativeTypeName("const int64_t")] long divisor_override);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_avg_pool2d_backward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_avg_pool2d_backward([NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, bool ceil_mode, bool count_include_pad, [NativeTypeName("const int64_t")] long divisor_override);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_avg_pool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_avg_pool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, bool ceil_mode, bool count_include_pad, [NativeTypeName("const int64_t")] long divisor_override);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_avg_pool3d_backward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_avg_pool3d_backward([NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, bool ceil_mode, bool count_include_pad, [NativeTypeName("const int64_t")] long divisor_override);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_baddbmm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_baddbmm([NativeTypeName("const Tensor")] OpaqueTensor* batch1, [NativeTypeName("const Tensor")] OpaqueTensor* batch2, [NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const float")] float beta, [NativeTypeName("const float")] float alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_backward", ExactSpelling = true)]
	public static extern void Tensor_backward([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bincount", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bincount([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* weights, [NativeTypeName("const int64_t")] long minlength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_and", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_and([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_and_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_and_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_not", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_not([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_not_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_not_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_or", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_or([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_or_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_or_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_xor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_xor([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_xor_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_xor_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_left_shift", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_left_shift([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_left_shift_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_left_shift_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_right_shift", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bitwise_right_shift([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bitwise_right_shift_", ExactSpelling = true)]
	public static extern void Tensor_bitwise_right_shift_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_block_diag", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_block_diag([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bmm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bmm([NativeTypeName("const Tensor")] OpaqueTensor* b1wrapper, [NativeTypeName("const Tensor")] OpaqueTensor* b2wrapper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_broadcast_to", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_broadcast_to([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* shape, [NativeTypeName("const int")] int shape_len);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_broadcast_tensors", ExactSpelling = true)]
	public static extern void Tensor_broadcast_tensors([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bucketize", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bucketize([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* boundaries, [NativeTypeName("const bool")] bool out_int32, [NativeTypeName("const bool")] bool right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cartesian_prod", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cartesian_prod([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cat", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cat([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_channel_shuffle", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_channel_shuffle([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cdist", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cdist([NativeTypeName("const Tensor")] OpaqueTensor* x1, [NativeTypeName("const Tensor")] OpaqueTensor* x2, [NativeTypeName("const double")] double p, [NativeTypeName("const int64_t")] long compute_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clip_grad_norm_", ExactSpelling = true)]
	public static extern double Tensor_clip_grad_norm_([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length, [NativeTypeName("const double")] double max_norm, [NativeTypeName("const double")] double norm_type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clip_grad_value_", ExactSpelling = true)]
	public static extern void Tensor_clip_grad_value_([NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length, [NativeTypeName("const double")] double value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_parameters_to_vector", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_parameters_to_vector([NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vector_to_parameters", ExactSpelling = true)]
	public static extern void Tensor_vector_to_parameters([NativeTypeName("const Tensor")] OpaqueTensor* vec, [NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clone", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_clone([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_combinations", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_combinations([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int")] int r, [NativeTypeName("const bool")] bool with_replacement);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_contiguous", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_contiguous([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ceil", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ceil([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ceil_", ExactSpelling = true)]
	public static extern void Tensor_ceil_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_celu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_celu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_celu_", ExactSpelling = true)]
	public static extern void Tensor_celu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardshrink", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hardshrink([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* lambda);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_softshrink", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_softshrink([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* lambda);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cholesky", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cholesky([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool upper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cholesky_inverse", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cholesky_inverse([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool upper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cholesky_solve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cholesky_solve([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* tensor2, [NativeTypeName("const bool")] bool upper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_chunk", ExactSpelling = true)]
	public static extern void Tensor_chunk([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long chunks, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_clamp([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* min, [NativeTypeName("const Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_", ExactSpelling = true)]
	public static extern void Tensor_clamp_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* min, [NativeTypeName("const Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_tensor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_clamp_tensor([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* min, [NativeTypeName("const Tensor")] OpaqueTensor* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_tensor_", ExactSpelling = true)]
	public static extern void Tensor_clamp_tensor_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* min, [NativeTypeName("const Tensor")] OpaqueTensor* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_max", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_clamp_max([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_max_", ExactSpelling = true)]
	public static extern void Tensor_clamp_max_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_min", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_clamp_min([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* min);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_clamp_min_", ExactSpelling = true)]
	public static extern void Tensor_clamp_min_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Scalar")] OpaqueScalar* min);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_complex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_complex([NativeTypeName("const Tensor")] OpaqueTensor* real, [NativeTypeName("const Tensor")] OpaqueTensor* imag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conj", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conj([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_nonzero", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_is_nonzero([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conj_physical", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conj_physical([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conj_physical_", ExactSpelling = true)]
	public static extern void Tensor_conj_physical_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_conj", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_is_conj([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_resolve_conj", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_resolve_conj([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv1d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv2d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv3d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv1d_padding", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv1d_padding([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int")] int padding, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv2d_padding", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv2d_padding([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int")] int padding, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv3d_padding", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv3d_padding([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int")] int padding, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv_transpose1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv_transpose1d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* output_padding, [NativeTypeName("const int")] int output_paddingLength, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv_transpose2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv_transpose2d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* output_padding, [NativeTypeName("const int")] int output_paddingLength, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_conv_transpose3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_conv_transpose3d([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const Tensor")] OpaqueTensor* bias, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int strides_length, [NativeTypeName("const int64_t *")] long* paddings, [NativeTypeName("const int")] int paddings_length, [NativeTypeName("const int64_t *")] long* output_padding, [NativeTypeName("const int")] int output_paddingLength, [NativeTypeName("const int64_t *")] long* dilations, [NativeTypeName("const int")] int dilations_length, [NativeTypeName("int64_t")] long groups);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_copysign", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_copysign([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_copy_", ExactSpelling = true)]
	public static extern void Tensor_copy_([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cos", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cos([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_corrcoef", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_corrcoef([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cos_", ExactSpelling = true)]
	public static extern void Tensor_cos_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cosh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cosh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cosh_", ExactSpelling = true)]
	public static extern void Tensor_cosh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_count_nonzero", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_count_nonzero([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_len);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cov", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cov([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("int64_t")] long correction, [NativeTypeName("const Tensor")] OpaqueTensor* fweights, [NativeTypeName("const Tensor")] OpaqueTensor* aweights);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_cpu", ExactSpelling = true)]
	public static extern bool Tensor_is_cpu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cpu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cpu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cross", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cross([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cuda", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cuda([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_pin_memory", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_pin_memory([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_pinned", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_is_pinned([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cummax", ExactSpelling = true)]
	public static extern void Tensor_cummax([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cummin", ExactSpelling = true)]
	public static extern void Tensor_cummin([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cumprod", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cumprod([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cumsum", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cumsum([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_data", ExactSpelling = true)]
	public static extern void* Tensor_data([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_data_idx_float16", ExactSpelling = true)]
	public static extern float Tensor_data_idx_float16([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long i);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_data_idx_bfloat16", ExactSpelling = true)]
	public static extern float Tensor_data_idx_bfloat16([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long i);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_deg2rad", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_deg2rad([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_detach", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_detach([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_detach_", ExactSpelling = true)]
	public static extern void Tensor_detach_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_device_str", ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* Tensor_device_str([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_device_type", ExactSpelling = true)]
	public static extern int Tensor_device_type([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_device_index", ExactSpelling = true)]
	public static extern int Tensor_device_index([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diag", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diag([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long diagonal);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diag_embed", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diag_embed([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long offset, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_trace", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_trace([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diagflat", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diagflat([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long offset);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diagonal", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diagonal([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long offset, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diff", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diff([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* prepend, [NativeTypeName("const Tensor")] OpaqueTensor* append);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_free", ExactSpelling = true)]
	public static extern void Tensor_free([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dispose", ExactSpelling = true)]
	public static extern void Tensor_dispose([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dist", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_dist([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other, [NativeTypeName("const float")] float p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_div", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_div([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right, [NativeTypeName("const char *")] sbyte* rounding_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_div_", ExactSpelling = true)]
	public static extern void Tensor_div_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right, [NativeTypeName("const char *")] sbyte* rounding_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_div_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_div_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right, [NativeTypeName("const char *")] sbyte* rounding_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_div_scalar_", ExactSpelling = true)]
	public static extern void Tensor_div_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right, [NativeTypeName("const char *")] sbyte* rounding_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_dot([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_einsum", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_einsum([NativeTypeName("const char *")] sbyte* equation, [NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_element_size", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_element_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_elu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_elu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* alpha, [NativeTypeName("const Scalar")] OpaqueScalar* scale, [NativeTypeName("const Scalar")] OpaqueScalar* input_scale);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_elu_", ExactSpelling = true)]
	public static extern void Tensor_elu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* alpha, [NativeTypeName("const Scalar")] OpaqueScalar* scale, [NativeTypeName("const Scalar")] OpaqueScalar* input_scale);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_empty", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_empty([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_empty_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_empty_out([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_empty_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_empty_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_empty_strided", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_empty_strided([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int sz_length, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int str_length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_as_strided", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_as_strided([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int sz_length, [NativeTypeName("const int64_t *")] long* strides, [NativeTypeName("const int")] int str_length, [NativeTypeName("const int64_t")] long storage_offset);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eq", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_eq([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eq_", ExactSpelling = true)]
	public static extern void Tensor_eq_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eq_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_eq_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eq_scalar_", ExactSpelling = true)]
	public static extern void Tensor_eq_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_equal", ExactSpelling = true)]
	public static extern int Tensor_equal([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_exp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_exp([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_exp_", ExactSpelling = true)]
	public static extern void Tensor_exp_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_exp2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_exp2([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_expm1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_expm1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_expm1_", ExactSpelling = true)]
	public static extern void Tensor_expm1_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_expand", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_expand([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, bool @implicit);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_erf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erf_", ExactSpelling = true)]
	public static extern void Tensor_erf_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erfc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_erfc([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erfc_", ExactSpelling = true)]
	public static extern void Tensor_erfc_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erfinv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_erfinv([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_erfinv_", ExactSpelling = true)]
	public static extern void Tensor_erfinv_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eye", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_eye([NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long m, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eye_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_eye_out([NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long m, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fill_", ExactSpelling = true)]
	public static extern void Tensor_fill_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_flatten", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_flatten([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long start, [NativeTypeName("const int64_t")] long end);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_flip", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_flip([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fliplr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fliplr([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_flipud", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_flipud([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_float_power", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_float_power([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* exponent);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_floor([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor_", ExactSpelling = true)]
	public static extern void Tensor_floor_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor_divide", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_floor_divide([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor_divide_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_floor_divide_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor_divide_", ExactSpelling = true)]
	public static extern void Tensor_floor_divide_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_floor_divide_scalar_", ExactSpelling = true)]
	public static extern void Tensor_floor_divide_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_true_divide", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_true_divide([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_true_divide_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_true_divide_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_true_divide_", ExactSpelling = true)]
	public static extern void Tensor_true_divide_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_true_divide_scalar_", ExactSpelling = true)]
	public static extern void Tensor_true_divide_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_frac", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_frac([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_frac_", ExactSpelling = true)]
	public static extern void Tensor_frac_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fmax([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fmin([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmod", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fmod([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmod_", ExactSpelling = true)]
	public static extern void Tensor_fmod_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmod_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fmod_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fmod_scalar_", ExactSpelling = true)]
	public static extern void Tensor_fmod_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_frexp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_frexp([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *")] OpaqueTensor** exponent);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_full", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_full([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_full_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_full_out([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_full_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_full_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_digamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_digamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_digamma_", ExactSpelling = true)]
	public static extern void Tensor_digamma_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lgamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lgamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lgamma_", ExactSpelling = true)]
	public static extern void Tensor_lgamma_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mvlgamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mvlgamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mvlgamma_", ExactSpelling = true)]
	public static extern void Tensor_mvlgamma_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gather", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gather([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ge", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ge([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ge_", ExactSpelling = true)]
	public static extern void Tensor_ge_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ge_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ge_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ge_scalar_", ExactSpelling = true)]
	public static extern void Tensor_ge_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gelu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gelu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gelu_", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gelu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_glu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_glu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get1([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get3", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get3([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get4", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get4([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get5", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get5([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4, [NativeTypeName("int64_t")] long index5);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_get6", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_get6([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4, [NativeTypeName("int64_t")] long index5, [NativeTypeName("int64_t")] long index6);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gcd", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gcd([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gcd_", ExactSpelling = true)]
	public static extern void Tensor_gcd_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_grad", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_grad([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set_grad", ExactSpelling = true)]
	public static extern void Tensor_set_grad([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gt([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gt_", ExactSpelling = true)]
	public static extern void Tensor_gt_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gt_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_gt_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_gt_scalar_", ExactSpelling = true)]
	public static extern void Tensor_gt_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardtanh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hardtanh([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Scalar")] OpaqueScalar* min, [NativeTypeName("Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardtanh_", ExactSpelling = true)]
	public static extern void Tensor_hardtanh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Scalar")] OpaqueScalar* min, [NativeTypeName("Scalar")] OpaqueScalar* max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_heaviside", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_heaviside([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* values);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hypot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hypot([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_i0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_i0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_igamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_igamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_igammac", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_igammac([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardsigmoid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hardsigmoid([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardsigmoid_", ExactSpelling = true)]
	public static extern void Tensor_hardsigmoid_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardswish", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hardswish([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hardswish_", ExactSpelling = true)]
	public static extern void Tensor_hardswish_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_histc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_histc([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long bins, [NativeTypeName("const int64_t")] long min, [NativeTypeName("const int64_t")] long max);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_imag", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_imag([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_add", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_index_add([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_add_", ExactSpelling = true)]
	public static extern void Tensor_index_add_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source, [NativeTypeName("const Scalar")] OpaqueScalar* alpha);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_copy", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_index_copy([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_copy_", ExactSpelling = true)]
	public static extern void Tensor_index_copy_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_fill", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_index_fill([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_fill_", ExactSpelling = true)]
	public static extern void Tensor_index_fill_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_indices", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_indices([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_index([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* indexStarts, [NativeTypeName("const int64_t *")] long* indexEnds, [NativeTypeName("const int64_t *")] long* indexSteps, [NativeTypeName("const Tensor *")] OpaqueTensor** indexTensors, [NativeTypeName("const int")] int indicesLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_put_scalar_", ExactSpelling = true)]
	public static extern void Tensor_index_put_scalar_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* indexStarts, [NativeTypeName("const int64_t *")] long* indexEnds, [NativeTypeName("const int64_t *")] long* indexSteps, [NativeTypeName("const Tensor *")] OpaqueTensor** indexTensors, [NativeTypeName("const int")] int indicesLength, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_put_", ExactSpelling = true)]
	public static extern void Tensor_index_put_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* indexStarts, [NativeTypeName("const int64_t *")] long* indexEnds, [NativeTypeName("const int64_t *")] long* indexSteps, [NativeTypeName("const Tensor *")] OpaqueTensor** indexTensors, [NativeTypeName("const int")] int indicesLength, [NativeTypeName("const Tensor")] OpaqueTensor* value, [NativeTypeName("const bool")] bool accumulate = false);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_index_select", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_index_select([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("Tensor")] OpaqueTensor* index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_inner", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_inner([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_inverse", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_inverse([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_contiguous", ExactSpelling = true)]
	public static extern int Tensor_is_contiguous([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_leaf", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_is_leaf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_sparse", ExactSpelling = true)]
	public static extern int Tensor_is_sparse([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isclose", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isclose([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other, [NativeTypeName("const double")] double rtol, [NativeTypeName("const double")] double atol, [NativeTypeName("const bool")] bool equal_nan);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isin([NativeTypeName("const Tensor")] OpaqueTensor* elements, [NativeTypeName("const Tensor")] OpaqueTensor* test_elements, bool assume_unique, bool invert);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isinf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isinf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isfinite", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isfinite([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isposinf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isposinf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isneginf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isneginf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isnan", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isnan([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_isreal", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_isreal([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_item", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Tensor_item([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_kron", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_kron([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_kthvalue", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_kthvalue([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("int64_t")] long k, [NativeTypeName("int64_t")] long dim, bool keepdim, [NativeTypeName("Tensor *")] OpaqueTensor** @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lcm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lcm([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lcm_", ExactSpelling = true)]
	public static extern void Tensor_lcm_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ldexp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ldexp([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ldexp_", ExactSpelling = true)]
	public static extern void Tensor_ldexp_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_le", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_le([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_le_", ExactSpelling = true)]
	public static extern void Tensor_le_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_le_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_le_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_le_scalar_", ExactSpelling = true)]
	public static extern void Tensor_le_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_leaky_relu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_leaky_relu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* negval);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_leaky_relu_", ExactSpelling = true)]
	public static extern void Tensor_leaky_relu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* negval);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lerp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lerp([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* end, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lerp_", ExactSpelling = true)]
	public static extern void Tensor_lerp_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* end, [NativeTypeName("const Tensor")] OpaqueTensor* weight);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_linspace", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_linspace([NativeTypeName("const double")] double start, [NativeTypeName("const double")] double end, [NativeTypeName("const int64_t")] long steps, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logspace", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logspace([NativeTypeName("const double")] double start, [NativeTypeName("const double")] double end, [NativeTypeName("const int64_t")] long steps, double @base, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_load", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_load([NativeTypeName("const char *")] sbyte* location);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_log([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log_", ExactSpelling = true)]
	public static extern void Tensor_log_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log10", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_log10([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log10_", ExactSpelling = true)]
	public static extern void Tensor_log10_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log1p", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_log1p([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log1p_", ExactSpelling = true)]
	public static extern void Tensor_log1p_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_log2([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log2_", ExactSpelling = true)]
	public static extern void Tensor_log2_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log_sigmoid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_log_sigmoid([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logaddexp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logaddexp([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logaddexp2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logaddexp2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logcumsumexp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logcumsumexp([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const long")] int dimension);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logsumexp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logsumexp([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const long")] int dimension, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_and", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logical_and([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_and_", ExactSpelling = true)]
	public static extern void Tensor_logical_and_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_not", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logical_not([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_not_", ExactSpelling = true)]
	public static extern void Tensor_logical_not_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_or", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logical_or([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_or_", ExactSpelling = true)]
	public static extern void Tensor_logical_or_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_xor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logical_xor([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logical_xor_", ExactSpelling = true)]
	public static extern void Tensor_logical_xor_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logit", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logit([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double *")] double* eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logit_", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logit_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double *")] double* eps);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lt([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lt_", ExactSpelling = true)]
	public static extern void Tensor_lt_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lt_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lt_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lt_scalar_", ExactSpelling = true)]
	public static extern void Tensor_lt_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool pivot, bool get_infos, [NativeTypeName("Tensor *")] OpaqueTensor** infos, [NativeTypeName("Tensor *")] OpaqueTensor** pivots);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lu_solve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lu_solve([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* LU_data, [NativeTypeName("const Tensor")] OpaqueTensor* LU_pivots);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_lu_unpack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_lu_unpack([NativeTypeName("const Tensor")] OpaqueTensor* LU_data, [NativeTypeName("const Tensor")] OpaqueTensor* LU_pivots, bool unpack_data, bool unpack_pivots, [NativeTypeName("Tensor *")] OpaqueTensor** L, [NativeTypeName("Tensor *")] OpaqueTensor** U);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_masked_fill", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_masked_fill([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* mask, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_masked_fill_", ExactSpelling = true)]
	public static extern void Tensor_masked_fill_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* mask, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_masked_scatter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_masked_scatter([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* mask, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_masked_scatter_", ExactSpelling = true)]
	public static extern void Tensor_masked_scatter_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* mask, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_masked_select", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_masked_select([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* mask);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_matmul", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_matmul([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_matrix_exp", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_matrix_exp([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_along_dimension", ExactSpelling = true)]
	public static extern void Tensor_max_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keep_dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_elementwise", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_elementwise([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_pool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_pool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_pool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool1d_with_indices", ExactSpelling = true)]
	public static extern void Tensor_max_pool1d_with_indices([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool2d_with_indices", ExactSpelling = true)]
	public static extern void Tensor_max_pool2d_with_indices([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_pool3d_with_indices", ExactSpelling = true)]
	public static extern void Tensor_max_pool3d_with_indices([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* dilation, [NativeTypeName("const int")] int dilationLength, bool ceil_mode);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_unpool1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_unpool1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_unpool2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_unpool2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_max_unpool3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_max_unpool3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices, [NativeTypeName("const int64_t *")] long* kernelSize, [NativeTypeName("const int")] int kernelSizeLength, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* padding, [NativeTypeName("const int")] int paddingLength, [NativeTypeName("const int64_t *")] long* stride, [NativeTypeName("const int")] int strideLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mean", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mean([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mean_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mean_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_median", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_median([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mode", ExactSpelling = true)]
	public static extern void Tensor_mode([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keep_dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_min", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_min([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_min_elementwise", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_min_elementwise([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_min_along_dimension", ExactSpelling = true)]
	public static extern void Tensor_min_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keep_dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mm([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mv([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_movedim", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_movedim([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* src, [NativeTypeName("const int")] int src_len, [NativeTypeName("const int64_t *")] long* dst, [NativeTypeName("const int")] int dst_len);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_msort", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_msort([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mul", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mul([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mul_", ExactSpelling = true)]
	public static extern void Tensor_mul_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mul_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mul_scalar([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* scalar);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mul_scalar_", ExactSpelling = true)]
	public static extern void Tensor_mul_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* scalar);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nanmean", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nanmean([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t *")] long* dims, [NativeTypeName("const int")] int dims_len, bool keepdim, [NativeTypeName("int8_t")] sbyte scalar_type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nanmedian", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nanmedian([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nanquantile", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nanquantile([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* q, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keep_dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nansum", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nansum([NativeTypeName("const Tensor")] OpaqueTensor* input);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nan_to_num", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nan_to_num([NativeTypeName("const Tensor")] OpaqueTensor* input, double* nan, double* posinf, double* neginf);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_narrow", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_narrow([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("int64_t")] long start, [NativeTypeName("int64_t")] long length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ndimension", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_ndimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ne", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ne([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ne_", ExactSpelling = true)]
	public static extern void Tensor_ne_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ne_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ne_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ne_scalar_", ExactSpelling = true)]
	public static extern void Tensor_ne_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_neg", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_neg([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_neg_", ExactSpelling = true)]
	public static extern void Tensor_neg_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_is_neg", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_is_neg([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_resolve_neg", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_resolve_neg([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_new", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_new(void* data, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> deleter, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int szlength, [NativeTypeName("int8_t")] sbyte scalar_type, [NativeTypeName("int8_t")] sbyte dtype, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_frombuffer", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_frombuffer(void* data, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> deleter, [NativeTypeName("const int64_t")] long count, [NativeTypeName("const ptrdiff_t")] nint offset, [NativeTypeName("int8_t")] sbyte scalar_type, [NativeTypeName("int8_t")] sbyte dtype, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newInt64", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newInt64([NativeTypeName("int64_t *")] long* data, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> deleter, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int szlength, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newFloat16", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newFloat16(float* rawArray, [NativeTypeName("uint16_t *")] ushort* dataArray, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> deleter, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int szlength, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newBFloat16", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newBFloat16(float* rawArray, [NativeTypeName("uint16_t *")] ushort* dataArray, [NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> deleter, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int szlength, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newInt8Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newInt8Scalar([NativeTypeName("int8_t")] sbyte data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newByteScalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newByteScalar([NativeTypeName("char")] sbyte data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newBoolScalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newBoolScalar(bool data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newFloat16Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newFloat16Scalar(float data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newBFloat16Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newBFloat16Scalar(float data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newInt16Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newInt16Scalar(short data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newInt32Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newInt32Scalar(int data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newInt64Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newInt64Scalar([NativeTypeName("int64_t")] long data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newFloat32Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newFloat32Scalar(float data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newFloat64Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newFloat64Scalar(double data, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newComplexFloat32Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newComplexFloat32Scalar(float real, float imaginary, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_newComplexFloat64Scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_newComplexFloat64Scalar(double real, double imaginary, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nextafter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nextafter([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_nonzero", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_nonzero([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_norm([NativeTypeName("const Tensor")] OpaqueTensor* tensor, float p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_norm_along_dimension", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_norm_along_dimension([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keepdim, float p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_tensordot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_tensordot([NativeTypeName("const Tensor")] OpaqueTensor* input1, [NativeTypeName("const Tensor")] OpaqueTensor* input2, [NativeTypeName("const int64_t *")] long* dims1, [NativeTypeName("const int")] int dims1_length, [NativeTypeName("const int64_t *")] long* dims2, [NativeTypeName("const int")] int dims2_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_numel", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_numel([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ones", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ones([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ones_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ones_out([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ones_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ones_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ormqr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ormqr([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* tau, [NativeTypeName("const Tensor")] OpaqueTensor* other, bool left, bool transpose);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_outer", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_outer([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mT", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mT([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_mH", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_mH([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_permute", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_permute([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_polar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_polar([NativeTypeName("const Tensor")] OpaqueTensor* abs, [NativeTypeName("const Tensor")] OpaqueTensor* angle);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_polygamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_polygamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_polygamma_", ExactSpelling = true)]
	public static extern void Tensor_polygamma_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_positive", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_positive([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_pow", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_pow([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* exponent);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_pow_", ExactSpelling = true)]
	public static extern void Tensor_pow_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* exponent);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_pow_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_pow_scalar([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* scalar);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_pow_scalar_", ExactSpelling = true)]
	public static extern void Tensor_pow_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* scalar);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_prelu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_prelu([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_quantile", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_quantile([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* q, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool keep_dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rad2deg", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rad2deg([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rand", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rand([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rand_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rand_out([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rand_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rand_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randint([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long low, [NativeTypeName("const int64_t")] long high, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randint_out([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long low, [NativeTypeName("const int64_t")] long high, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randint_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long low, [NativeTypeName("const int64_t")] long high, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint_bool", ExactSpelling = true)]
	[return: NativeTypeName("int32_t")]
	public static extern int Tensor_randint_bool([NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint_int", ExactSpelling = true)]
	[return: NativeTypeName("int32_t")]
	public static extern int Tensor_randint_int([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int32_t")] int low, [NativeTypeName("const int32_t")] int high);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randint_long", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_randint_long([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long low, [NativeTypeName("const int64_t")] long high);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rand_float", ExactSpelling = true)]
	public static extern double Tensor_rand_float([NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randn_float", ExactSpelling = true)]
	public static extern double Tensor_randn_float([NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randn([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randn_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randn_out([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randn_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randn_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randperm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randperm([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_randperm_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_randperm_out([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_from_file", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_from_file([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const int8_t")] sbyte shared, [NativeTypeName("const int64_t")] long size, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ravel", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ravel([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_real", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_real([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_reciprocal", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_reciprocal([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_reciprocal_", ExactSpelling = true)]
	public static extern void Tensor_reciprocal_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_relu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_relu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_relu_", ExactSpelling = true)]
	public static extern void Tensor_relu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_relu6", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_relu6([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_relu6_", ExactSpelling = true)]
	public static extern void Tensor_relu6_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rrelu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rrelu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double lower, [NativeTypeName("const double")] double upper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rrelu_", ExactSpelling = true)]
	public static extern void Tensor_rrelu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double lower, [NativeTypeName("const double")] double upper);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_repeat", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_repeat([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_repeat_interleave", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_repeat_interleave([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* repeats, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const int64_t")] long output_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_repeat_interleave_int64", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_repeat_interleave_int64([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long repeats, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const int64_t")] long output_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_requires_grad", ExactSpelling = true)]
	public static extern int Tensor_requires_grad([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_reshape", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_reshape([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* shape, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_roll", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_roll([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* shifts, [NativeTypeName("const int")] int shLength, [NativeTypeName("const int64_t *")] long* dims, [NativeTypeName("const int")] int dimLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rot90", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rot90([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long k, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_round", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_round([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long decimals);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_round_", ExactSpelling = true)]
	public static extern void Tensor_round_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long decimals);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_remainder", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_remainder([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_remainder_", ExactSpelling = true)]
	public static extern void Tensor_remainder_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_remainder_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_remainder_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_remainder_scalar_", ExactSpelling = true)]
	public static extern void Tensor_remainder_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_retain_grad", ExactSpelling = true)]
	public static extern void Tensor_retain_grad([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_result_type", ExactSpelling = true)]
	public static extern int Tensor_result_type([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rsqrt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rsqrt([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rsqrt_", ExactSpelling = true)]
	public static extern void Tensor_rsqrt_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_renorm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_renorm([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const float")] float p, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const float")] float maxnorm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_select", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_select([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_selu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_selu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_selu_", ExactSpelling = true)]
	public static extern void Tensor_selu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sigmoid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sigmoid([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sigmoid_", ExactSpelling = true)]
	public static extern void Tensor_sigmoid_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sign", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sign([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sign_", ExactSpelling = true)]
	public static extern void Tensor_sign_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sgn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sgn([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sgn_", ExactSpelling = true)]
	public static extern void Tensor_sgn_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_signbit", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_signbit([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_silu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_silu([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_silu_", ExactSpelling = true)]
	public static extern void Tensor_silu_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sin", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sin([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sin_", ExactSpelling = true)]
	public static extern void Tensor_sin_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sinc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sinc([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sinc_", ExactSpelling = true)]
	public static extern void Tensor_sinc_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sinh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sinh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sinh_", ExactSpelling = true)]
	public static extern void Tensor_sinh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_softplus", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_softplus([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* beta, [NativeTypeName("const Scalar")] OpaqueScalar* threshold);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sort", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sort([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool descending, [NativeTypeName("const bool")] bool stable, [NativeTypeName("Tensor *")] OpaqueTensor** indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sqrt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sqrt([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sqrt_", ExactSpelling = true)]
	public static extern void Tensor_sqrt_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_std", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_std([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool unbiased);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_std_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_std_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool unbiased, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_std_mean", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_std_mean([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool unbiased, [NativeTypeName("Tensor *")] OpaqueTensor** mean);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_std_mean_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_std_mean_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool unbiased, bool keepdim, [NativeTypeName("Tensor *")] OpaqueTensor** mean);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_var", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_var([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_var_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_var_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool unbiased, bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_var_mean", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_var_mean([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool unbiased, [NativeTypeName("Tensor *")] OpaqueTensor** var);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_var_mean_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_var_mean_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool unbiased, bool keepdim, [NativeTypeName("Tensor *")] OpaqueTensor** mean);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sub", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sub([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sub_", ExactSpelling = true)]
	public static extern void Tensor_sub_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sub_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sub_scalar([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sub_scalar_", ExactSpelling = true)]
	public static extern void Tensor_sub_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Scalar")] OpaqueScalar* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sum", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sum([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sum_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sum_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dimensions, int length, bool keepdim, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_prod", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_prod([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_prod_along_dimensions", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_prod_along_dimensions([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dimension, bool keepdim, bool has_type, [NativeTypeName("const int8_t")] sbyte dtype);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_save", ExactSpelling = true)]
	public static extern void Tensor_save([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char *")] sbyte* location);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_scatter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_scatter([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_scatter_", ExactSpelling = true)]
	public static extern void Tensor_scatter_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_diagonal_scatter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_diagonal_scatter([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* source, [NativeTypeName("const int64_t")] long offset, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_select_scatter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_select_scatter([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* source, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_slice_scatter", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_slice_scatter([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* source, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const int64_t *")] long* start, [NativeTypeName("const int64_t *")] long* end, [NativeTypeName("const int64_t")] long step);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_scatter_add", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_scatter_add([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_scatter_add_", ExactSpelling = true)]
	public static extern void Tensor_scatter_add_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const Tensor")] OpaqueTensor* index, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_searchsorted_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_searchsorted_t([NativeTypeName("const Tensor")] OpaqueTensor* sorted_sequence, [NativeTypeName("const Tensor")] OpaqueTensor* values, [NativeTypeName("const bool")] bool out_int32, [NativeTypeName("const bool")] bool right, [NativeTypeName("const Tensor")] OpaqueTensor* sorter);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_searchsorted_s", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_searchsorted_s([NativeTypeName("const Tensor")] OpaqueTensor* sorted_sequence, [NativeTypeName("const Scalar")] OpaqueScalar* values, [NativeTypeName("const bool")] bool out_int32, [NativeTypeName("const bool")] bool right, [NativeTypeName("const Tensor")] OpaqueTensor* sorter);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_histogram_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_histogram_t([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* bins, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const bool")] bool density, [NativeTypeName("Tensor *")] OpaqueTensor** r_bin_edges);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_histogram_i", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_histogram_i([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long bins, [NativeTypeName("const double *")] double* range, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const bool")] bool density, [NativeTypeName("Tensor *")] OpaqueTensor** r_bin_edges);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_histogram_out_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_histogram_out_t([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* bins, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const bool")] bool density, [NativeTypeName("Tensor *")] OpaqueTensor** hist, [NativeTypeName("Tensor *")] OpaqueTensor** bin_edges, [NativeTypeName("Tensor *")] OpaqueTensor** r_bin_edges);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_histogram_out_i", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_histogram_out_i([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int64_t")] long bins, [NativeTypeName("const double *")] double* range, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* weight, [NativeTypeName("const bool")] bool density, [NativeTypeName("Tensor *")] OpaqueTensor** hist, [NativeTypeName("Tensor *")] OpaqueTensor** bin_edges, [NativeTypeName("Tensor *")] OpaqueTensor** r_bin_edges);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set_", ExactSpelling = true)]
	public static extern void Tensor_set_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* source);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set_requires_grad", ExactSpelling = true)]
	public static extern void Tensor_set_requires_grad([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set1", ExactSpelling = true)]
	public static extern void Tensor_set1([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set2", ExactSpelling = true)]
	public static extern void Tensor_set2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set3", ExactSpelling = true)]
	public static extern void Tensor_set3([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set4", ExactSpelling = true)]
	public static extern void Tensor_set4([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set5", ExactSpelling = true)]
	public static extern void Tensor_set5([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4, [NativeTypeName("int64_t")] long index5, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_set6", ExactSpelling = true)]
	public static extern void Tensor_set6([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long index1, [NativeTypeName("int64_t")] long index2, [NativeTypeName("int64_t")] long index3, [NativeTypeName("int64_t")] long index4, [NativeTypeName("int64_t")] long index5, [NativeTypeName("int64_t")] long index6, [NativeTypeName("const Tensor")] OpaqueTensor* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_size", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sizes", ExactSpelling = true)]
	public static extern void Tensor_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, long*> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_slice", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_slice([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("int64_t")] long start, [NativeTypeName("int64_t")] long finish, [NativeTypeName("int64_t")] long step);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sparse", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sparse([NativeTypeName("Tensor")] OpaqueTensor* indices, [NativeTypeName("Tensor")] OpaqueTensor* values, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_split_with_size", ExactSpelling = true)]
	public static extern void Tensor_split_with_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long split_size, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_split_with_sizes", ExactSpelling = true)]
	public static extern void Tensor_split_with_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_squeeze", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_squeeze([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_squeeze_no_dim", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_squeeze_no_dim([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_squeeze_", ExactSpelling = true)]
	public static extern void Tensor_squeeze_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_squeeze_no_dim_", ExactSpelling = true)]
	public static extern void Tensor_squeeze_no_dim_([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_stack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_stack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hstack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hstack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vstack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_vstack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dstack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_dstack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_column_stack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_column_stack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_row_stack", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_row_stack([NativeTypeName("const Tensor *")] OpaqueTensor** tensor, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_meshgrid", ExactSpelling = true)]
	public static extern void Tensor_meshgrid([NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length, [NativeTypeName("const char *")] sbyte* indexing, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_stride", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Tensor_stride([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_strides", ExactSpelling = true)]
	public static extern void Tensor_strides([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, long*> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_take", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_take([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_take_along_dim_dflt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_take_along_dim_dflt([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_take_along_dim", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_take_along_dim([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* indices, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tan", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_tan([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tan_", ExactSpelling = true)]
	public static extern void Tensor_tan_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tanh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_tanh([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tanh_", ExactSpelling = true)]
	public static extern void Tensor_tanh_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_t([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tensor_split_with_size", ExactSpelling = true)]
	public static extern void Tensor_tensor_split_with_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long split_size, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tensor_split_with_sizes", ExactSpelling = true)]
	public static extern void Tensor_tensor_split_with_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tensor_split_with_tensor_sizes", ExactSpelling = true)]
	public static extern void Tensor_tensor_split_with_tensor_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const Tensor")] OpaqueTensor* sizes, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vsplit_with_size", ExactSpelling = true)]
	public static extern void Tensor_vsplit_with_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long split_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vsplit_with_sizes", ExactSpelling = true)]
	public static extern void Tensor_vsplit_with_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hsplit_with_size", ExactSpelling = true)]
	public static extern void Tensor_hsplit_with_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long split_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hsplit_with_sizes", ExactSpelling = true)]
	public static extern void Tensor_hsplit_with_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dsplit_with_size", ExactSpelling = true)]
	public static extern void Tensor_dsplit_with_size([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long split_size);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_dsplit_with_sizes", ExactSpelling = true)]
	public static extern void Tensor_dsplit_with_sizes([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tile", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_tile([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* rep, [NativeTypeName("const int")] int rep_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tril", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_tril([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long diagonal, [NativeTypeName("const bool")] bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_triu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_triu([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long diagonal, [NativeTypeName("const bool")] bool inplace);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_tril_indices", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_tril_indices([NativeTypeName("const int64_t")] long row, [NativeTypeName("const int64_t")] long col, [NativeTypeName("const int64_t")] long offset, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_triu_indices", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_triu_indices([NativeTypeName("const int64_t")] long row, [NativeTypeName("const int64_t")] long col, [NativeTypeName("const int64_t")] long offset, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_transpose", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_transpose([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_transpose_", ExactSpelling = true)]
	public static extern void Tensor_transpose_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim1, [NativeTypeName("const int64_t")] long dim2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_threshold", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_threshold([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* threshold, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_threshold_", ExactSpelling = true)]
	public static extern void Tensor_threshold_([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* threshold, [NativeTypeName("const Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cumulative_trapezoid_x", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cumulative_trapezoid_x([NativeTypeName("const Tensor")] OpaqueTensor* y, [NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cumulative_trapezoid_dx", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_cumulative_trapezoid_dx([NativeTypeName("const Tensor")] OpaqueTensor* y, [NativeTypeName("const double")] double dx, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_trapezoid_x", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_trapezoid_x([NativeTypeName("const Tensor")] OpaqueTensor* y, [NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_trapezoid_dx", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_trapezoid_dx([NativeTypeName("const Tensor")] OpaqueTensor* y, [NativeTypeName("const double")] double dx, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_to_dense", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_to_dense([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_to_device", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_to_device([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool copy, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_to_type", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_to_type([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int8_t")] sbyte scalar_type, [NativeTypeName("const bool")] bool copy, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_to_type_and_device", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_to_type_and_device([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool copy, [NativeTypeName("const bool")] bool non_blocking);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_topk", ExactSpelling = true)]
	public static extern void Tensor_topk([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int")] int k, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool largest, [NativeTypeName("const bool")] bool sorted);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_trunc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_trunc([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_trunc_", ExactSpelling = true)]
	public static extern void Tensor_trunc_([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_type", ExactSpelling = true)]
	[return: NativeTypeName("int8_t")]
	public static extern sbyte Tensor_get_Type([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unbind", ExactSpelling = true)]
	public static extern void Tensor_unbind([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unique", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unique([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool sorted, [NativeTypeName("const bool")] bool return_inverse, [NativeTypeName("const bool")] bool return_counts, [NativeTypeName("Tensor *")] OpaqueTensor** inverse_indices, [NativeTypeName("Tensor *")] OpaqueTensor** counts);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unique_dim", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unique_dim([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool sorted, [NativeTypeName("const bool")] bool return_inverse, [NativeTypeName("const bool")] bool return_counts, [NativeTypeName("Tensor *")] OpaqueTensor** inverse_indices, [NativeTypeName("Tensor *")] OpaqueTensor** counts);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unique_consecutive", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unique_consecutive([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool return_inverse, [NativeTypeName("const bool")] bool return_counts, [NativeTypeName("Tensor *")] OpaqueTensor** inverse_indices, [NativeTypeName("Tensor *")] OpaqueTensor** counts);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unique_dim_consecutive", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unique_dim_consecutive([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("const bool")] bool return_inverse, [NativeTypeName("const bool")] bool return_counts, [NativeTypeName("Tensor *")] OpaqueTensor** inverse_indices, [NativeTypeName("Tensor *")] OpaqueTensor** counts);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unflatten", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unflatten([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dimension, [NativeTypeName("const int64_t *")] long* shape, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unfold", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unfold([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long dimension, [NativeTypeName("const int64_t")] long size, [NativeTypeName("const int64_t")] long step);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unsqueeze", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unsqueeze([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unsqueeze_", ExactSpelling = true)]
	public static extern void Tensor_unsqueeze_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest1d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest1d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest1d_backward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest1d_backward([NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* inputSize, [NativeTypeName("const int")] int inputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest2d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest2d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest2d_backward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest2d_backward([NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* inputSize, [NativeTypeName("const int")] int inputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest3d", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest3d([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_upsample_nearest3d_backward", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_upsample_nearest3d_backward([NativeTypeName("const Tensor")] OpaqueTensor* grad_output, [NativeTypeName("const int64_t *")] long* outputSize, [NativeTypeName("const int")] int outputSizeLength, [NativeTypeName("const int64_t *")] long* inputSize, [NativeTypeName("const int")] int inputSizeLength, [NativeTypeName("const double *")] double* scaleFactors, [NativeTypeName("const int")] int scaleFactorsLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_values", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_values([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_has_names", ExactSpelling = true)]
	public static extern bool Tensor_has_names([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_names", ExactSpelling = true)]
	public static extern void Tensor_names([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, sbyte**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rename", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rename([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rename_", ExactSpelling = true)]
	public static extern void Tensor_rename_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_refine_names", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_refine_names([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_flatten_names", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_flatten_names([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_unflatten_names", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_unflatten_names([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_align_to", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_align_to([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char **")] sbyte** names, [NativeTypeName("int64_t")] long nLength);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vander", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_vander([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long N, [NativeTypeName("const bool")] bool increasing);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_vdot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_vdot([NativeTypeName("const Tensor")] OpaqueTensor* left, [NativeTypeName("const Tensor")] OpaqueTensor* right);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_view", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_view([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* shape, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_view_as_complex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_view_as_complex([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_view_as_real", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_view_as_real([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_where", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_where([NativeTypeName("const Tensor")] OpaqueTensor* condition, [NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* y);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_where_list", ExactSpelling = true)]
	public static extern void Tensor_where_list([NativeTypeName("const Tensor")] OpaqueTensor* condition, [NativeTypeName("Tensor *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, OpaqueTensor**> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_xlogy", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_xlogy([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* y);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_xlogy_", ExactSpelling = true)]
	public static extern void Tensor_xlogy_([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* y);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_xlogy_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_xlogy_scalar([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Scalar")] OpaqueScalar* y);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_xlogy_scalar_", ExactSpelling = true)]
	public static extern void Tensor_xlogy_scalar_([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Scalar")] OpaqueScalar* y);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_zeros", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_zeros([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_zeros_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_zeros_out([NativeTypeName("const int64_t *")] long* sizes, [NativeTypeName("const int")] int length, [NativeTypeName("const Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_zeros_like", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_zeros_like([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bernoulli", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bernoulli([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_binomial", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_binomial([NativeTypeName("const Tensor")] OpaqueTensor* count, [NativeTypeName("const Tensor")] OpaqueTensor* prob, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_multinomial", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_multinomial([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long num_samples, [NativeTypeName("const bool")] bool replacement, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_poisson", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_poisson([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_sample_dirichlet_", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_sample_dirichlet_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_standard_gamma_", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_standard_gamma_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bernoulli_0", ExactSpelling = true)]
	public static extern void Tensor_bernoulli_0([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double p, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bernoulli_1", ExactSpelling = true)]
	public static extern void Tensor_bernoulli_1([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* p_tensor, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_cauchy_", ExactSpelling = true)]
	public static extern void Tensor_cauchy_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double median, [NativeTypeName("const double")] double sigma, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_exponential_", ExactSpelling = true)]
	public static extern void Tensor_exponential_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double lambda, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_geometric_", ExactSpelling = true)]
	public static extern void Tensor_geometric_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double p, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_normal_", ExactSpelling = true)]
	public static extern void Tensor_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double mean, double std, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_log_normal_", ExactSpelling = true)]
	public static extern void Tensor_log_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double mean, double std, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_random_", ExactSpelling = true)]
	public static extern void Tensor_random_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double low, double high, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_uniform_", ExactSpelling = true)]
	public static extern void Tensor_uniform_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double low, double high, [NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cond_int", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cond_int([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int")] int p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cond_float", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cond_float([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cond_str", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cond_str([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char *")] sbyte* p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cond_none", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cond_none([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cholesky", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cholesky([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cholesky_ex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cholesky_ex([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool check_errors, [NativeTypeName("Tensor *")] OpaqueTensor** info);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_cross", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_cross([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other, [NativeTypeName("const int64_t")] long dim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_det", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_det([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_logdet", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_logdet([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_slogdet", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_slogdet([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *")] OpaqueTensor** logabsdet);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_eig", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_eig([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *")] OpaqueTensor** eigenvectors);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_eigh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_eigh([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char")] sbyte UPLO, [NativeTypeName("Tensor *")] OpaqueTensor** eigenvectors);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_eig", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_eig([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool vectors, [NativeTypeName("Tensor *")] OpaqueTensor** eigenvectors);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_eigvals", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_eigvals([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_eigvalsh", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_eigvalsh([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char")] sbyte UPLO);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_geqrf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_geqrf([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor *")] OpaqueTensor** tau);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_householder_product", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_householder_product([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* tau);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_inv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_inv([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_inv_ex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_inv_ex([NativeTypeName("const Tensor")] OpaqueTensor* tensor, bool check_errors, [NativeTypeName("Tensor *")] OpaqueTensor** info);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_lstsq_none", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_lstsq_none([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const Tensor")] OpaqueTensor* B, [NativeTypeName("Tensor *")] OpaqueTensor** residuals, [NativeTypeName("Tensor *")] OpaqueTensor** rank, [NativeTypeName("Tensor *")] OpaqueTensor** singular_values);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_lstsq_rcond", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_lstsq_rcond([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const Tensor")] OpaqueTensor* B, [NativeTypeName("const double")] double rcond, [NativeTypeName("Tensor *")] OpaqueTensor** residuals, [NativeTypeName("Tensor *")] OpaqueTensor** rank, [NativeTypeName("Tensor *")] OpaqueTensor** singular_values);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_lu", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_lu([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const bool")] bool pivot, [NativeTypeName("Tensor *")] OpaqueTensor** L, [NativeTypeName("Tensor *")] OpaqueTensor** U);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_lu_factor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_lu_factor([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const bool")] bool pivot, [NativeTypeName("Tensor *")] OpaqueTensor** pivots);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_ldl_factor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_ldl_factor([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const bool")] bool hermitian, [NativeTypeName("Tensor *")] OpaqueTensor** pivots);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_ldl_factor_ex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_ldl_factor_ex([NativeTypeName("const Tensor")] OpaqueTensor* A, [NativeTypeName("const bool")] bool hermitian, [NativeTypeName("const bool")] bool check_errors, [NativeTypeName("Tensor *")] OpaqueTensor** pivots, [NativeTypeName("Tensor *")] OpaqueTensor** info);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_ldl_solve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_ldl_solve([NativeTypeName("const Tensor")] OpaqueTensor* LD, [NativeTypeName("const Tensor")] OpaqueTensor* pivots, [NativeTypeName("const Tensor")] OpaqueTensor* B, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_matrix_power", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_matrix_power([NativeTypeName("const Tensor")] OpaqueTensor* target, [NativeTypeName("const int64_t")] long n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_matrix_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_matrix_norm([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* ord, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_matrix_norm_fronuc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_matrix_norm_fronuc([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int8_t")] sbyte fronuc, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_matrix_rank", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_matrix_rank([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double atol, [NativeTypeName("const bool")] bool has_atol, [NativeTypeName("const double")] double rtol, [NativeTypeName("const bool")] bool has_rtol, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_matrix_rank_tensor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_matrix_rank_tensor([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* atol, [NativeTypeName("const Tensor")] OpaqueTensor* rtol, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_multi_dot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_multi_dot([NativeTypeName("const Tensor *")] OpaqueTensor** tensors, [NativeTypeName("const int")] int length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_norm_str", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_norm_str([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char *")] sbyte* p, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_norm_float", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_norm_float([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double p, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_norm_int", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_norm_int([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int")] int p, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_norm_opt", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_norm_opt([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_pinverse", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_pinverse([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double rcond, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_pinv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_pinv([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const double")] double atol, [NativeTypeName("const bool")] bool has_atol, [NativeTypeName("const double")] double rtol, [NativeTypeName("const bool")] bool has_rtol, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_pinv_tensor", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_pinv_tensor([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Tensor")] OpaqueTensor* atol, [NativeTypeName("const Tensor")] OpaqueTensor* rtol, [NativeTypeName("const bool")] bool hermitian);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_qr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_qr([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const char")] sbyte mode, [NativeTypeName("Tensor *")] OpaqueTensor** R);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_solve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_solve([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* other, bool left);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_solve_ex", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_solve_ex([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* other, bool left, bool check_errors, [NativeTypeName("Tensor *")] OpaqueTensor** S);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_solve_triangular", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_solve_triangular([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* other, bool upper, bool left, bool unitriangular);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_solve_triangular_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_solve_triangular_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* other, bool upper, bool left, bool unitriangular, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_svd", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_svd([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const bool")] bool full_matrices, [NativeTypeName("Tensor *")] OpaqueTensor** S, [NativeTypeName("Tensor *")] OpaqueTensor** Vh);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_svdvals", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_svdvals([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_tensorinv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_tensorinv([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long ind);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_tensorsolve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_tensorsolve([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* other, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_vector_norm", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_vector_norm([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const Scalar")] OpaqueScalar* ord, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("const bool")] bool keepdim);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_vander", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_vander([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long N);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_vecdot", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_vecdot([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* y, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSLinalg_lu_solve", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Linalg_lu_solve([NativeTypeName("const Tensor")] OpaqueTensor* B, [NativeTypeName("const Tensor")] OpaqueTensor* LU, [NativeTypeName("const Tensor")] OpaqueTensor* pivots, bool left, bool adjoint, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_airy_ai", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_airy_ai([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_airy_ai_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_airy_ai_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_j0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_j0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_j0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_j0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_j1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_j1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_j1_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_j1_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_y0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_y0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_y0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_y0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_y1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_y1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_bessel_y1_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_bessel_y1_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_i0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_i0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_i0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_i0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_i1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_i1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_i1_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_i1_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_k0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_k0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_k0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_k0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_k1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_k1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_modified_bessel_k1_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_modified_bessel_k1_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_scaled_modified_bessel_k0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_scaled_modified_bessel_k0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_scaled_modified_bessel_k0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_scaled_modified_bessel_k0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_scaled_modified_bessel_k1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_scaled_modified_bessel_k1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_scaled_modified_bessel_k1_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_scaled_modified_bessel_k1_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_spherical_bessel_j0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_spherical_bessel_j0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_spherical_bessel_j0_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_spherical_bessel_j0_out([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_t([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_t_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_t_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_u", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_u([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_u_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_u_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_v", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_v([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_v_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_v_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_w", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_w([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_chebyshev_polynomial_w_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_chebyshev_polynomial_w_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_t", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_t([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_t_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_t_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_u", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_u([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_u_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_u_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_v", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_v([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_v_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_v_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_w", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_w([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_shifted_chebyshev_polynomial_w_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_shifted_chebyshev_polynomial_w_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_hermite_polynomial_h", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_hermite_polynomial_h([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_hermite_polynomial_h_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_hermite_polynomial_h_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_hermite_polynomial_he", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_hermite_polynomial_he([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_hermite_polynomial_he_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_hermite_polynomial_he_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_laguerre_polynomial_l", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_laguerre_polynomial_l([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_laguerre_polynomial_l_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_laguerre_polynomial_l_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_legendre_polynomial_p", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_legendre_polynomial_p([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_legendre_polynomial_p_out", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_legendre_polynomial_p_out([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("const Tensor")] OpaqueTensor* n, [NativeTypeName("Tensor")] OpaqueTensor* @out);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_entr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_entr([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erf", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_erf([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erfc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_erfc([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erfcx", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_erfcx([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erfinv", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_erfinv([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_expit", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_expit([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_expm1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_expm1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_exp2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_exp2([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_gammaln", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_gammaln([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_gammainc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_gammainc([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_gammaincc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_gammaincc([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_polygamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_polygamma([NativeTypeName("const int64_t")] long n, [NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_digamma", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_digamma([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_multigammaln", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_multigammaln([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long p);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_i0", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_i0([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_i0e", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_i0e([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_i1", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_i1([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_i1e", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_i1e([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_logit", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_logit([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_log_softmax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_log_softmax([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("int8_t")] sbyte scalar_type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_softmax", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_softmax([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("int64_t")] long dim, [NativeTypeName("int8_t")] sbyte scalar_type);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_ndtr", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_ndtr([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_ndtri", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_ndtri([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_sinc", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_sinc([NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_xlog1py", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_xlog1py([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_zeta", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Special_zeta([NativeTypeName("const Tensor")] OpaqueTensor* input, [NativeTypeName("const Tensor")] OpaqueTensor* other);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_calculate_gain", ExactSpelling = true)]
	public static extern double Init_calculate_gain([NativeTypeName("int64_t")] long nonlinearity, double param1);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_constant_", ExactSpelling = true)]
	public static extern void Init_constant_([NativeTypeName("Tensor")] OpaqueTensor* tensor, [NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_dirac_", ExactSpelling = true)]
	public static extern void Init_dirac_([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_eye_", ExactSpelling = true)]
	public static extern void Init_eye_([NativeTypeName("Tensor")] OpaqueTensor* matrix);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_normal_", ExactSpelling = true)]
	public static extern void Init_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double mean, double std);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_trunc_normal_", ExactSpelling = true)]
	public static extern void Init_trunc_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double mean, double std, double a, double b);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_ones_", ExactSpelling = true)]
	public static extern void Init_ones_([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_orthogonal_", ExactSpelling = true)]
	public static extern void Init_orthogonal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double gain);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_sparse_", ExactSpelling = true)]
	public static extern void Init_sparse_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double sparsity, double std);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_uniform_", ExactSpelling = true)]
	public static extern void Init_uniform_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double low, double high);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_kaiming_normal_", ExactSpelling = true)]
	public static extern void Init_kaiming_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double a, [NativeTypeName("const int64_t")] long mode, [NativeTypeName("const int64_t")] long nonlinearity);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_kaiming_uniform_", ExactSpelling = true)]
	public static extern void Init_kaiming_uniform_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double a, [NativeTypeName("const int64_t")] long mode, [NativeTypeName("const int64_t")] long nonlinearity);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_xavier_normal_", ExactSpelling = true)]
	public static extern void Init_xavier_normal_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double gain);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_xavier_uniform_", ExactSpelling = true)]
	public static extern void Init_xavier_uniform_([NativeTypeName("Tensor")] OpaqueTensor* tensor, double gain);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSInit_zeros_", ExactSpelling = true)]
	public static extern void Init_zeros_([NativeTypeName("Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ifft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ifft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hfft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hfft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ihfft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ihfft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ifft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ifft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hfft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hfft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ihfft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ihfft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hfftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hfftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ihfftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ihfftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ifftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ifftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rfft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rfft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_irfft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_irfft([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t")] long n, [NativeTypeName("const int64_t")] long dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rfft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rfft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_irfft2", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_irfft2([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rfftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rfftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_irfftn", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_irfftn([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* s, [NativeTypeName("const int")] int s_length, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length, [NativeTypeName("int8_t")] sbyte norm);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fftfreq", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fftfreq([NativeTypeName("const int64_t")] long n, [NativeTypeName("const double")] double d, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_rfftfreq", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_rfftfreq([NativeTypeName("const int64_t")] long n, [NativeTypeName("const double")] double d, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_fftshift", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_fftshift([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_ifftshift", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_ifftshift([NativeTypeName("const Tensor")] OpaqueTensor* tensor, [NativeTypeName("const int64_t *")] long* dim, [NativeTypeName("const int")] int dim_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_bartlett_window", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_bartlett_window([NativeTypeName("const int64_t")] long len, bool periodic, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_blackman_window", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_blackman_window([NativeTypeName("const int64_t")] long len, bool periodic, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hamming_window", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hamming_window([NativeTypeName("const int64_t")] long len, bool periodic, double alpha, double beta, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_hann_window", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_hann_window([NativeTypeName("const int64_t")] long len, bool periodic, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_kaiser_window", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_kaiser_window([NativeTypeName("const int64_t")] long len, bool periodic, double beta, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index, [NativeTypeName("const bool")] bool requires_grad);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_stft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_stft([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("int64_t")] long n_fft, [NativeTypeName("int64_t")] long hop_length, [NativeTypeName("int64_t")] long win_length, [NativeTypeName("const Tensor")] OpaqueTensor* window, bool normalized, [NativeTypeName("int64_t")] long onesided, bool return_complex);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTensor_istft", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Tensor_istft([NativeTypeName("const Tensor")] OpaqueTensor* x, [NativeTypeName("int64_t")] long n_fft, [NativeTypeName("int64_t")] long hop_length, [NativeTypeName("int64_t")] long win_length, [NativeTypeName("const Tensor")] OpaqueTensor* window, bool center, bool normalized, [NativeTypeName("int64_t")] long onesided, [NativeTypeName("int64_t")] long length, bool return_complex);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_manual_seed", ExactSpelling = true)]
	public static extern void Torch_manual_seed([NativeTypeName("const int64_t")] long seed);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSCuda_manual_seed", ExactSpelling = true)]
	public static extern void Cuda_manual_seed([NativeTypeName("const int64_t")] long seed);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSCuda_manual_seed_all", ExactSpelling = true)]
	public static extern void Cuda_manual_seed_all([NativeTypeName("const int64_t")] long seed);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_manual_seed", ExactSpelling = true)]
	[return: NativeTypeName("Generator")]
	public static extern OpaqueGenerator* Generator_manual_seed([NativeTypeName("const int64_t")] long seed);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_gen_manual_seed", ExactSpelling = true)]
	public static extern void Generator_gen_manual_seed([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const int64_t")] long seed);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_get_rng_state", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Generator_get_rng_state([NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_set_rng_state", ExactSpelling = true)]
	public static extern void Generator_set_rng_state([NativeTypeName("const Generator")] OpaqueGenerator* gen, [NativeTypeName("const Tensor")] OpaqueTensor* tensor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_default_generator", ExactSpelling = true)]
	[return: NativeTypeName("Generator")]
	public static extern OpaqueGenerator* Generator_default_generator();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_new", ExactSpelling = true)]
	[return: NativeTypeName("Generator")]
	public static extern OpaqueGenerator* Generator_new([NativeTypeName("uint64_t")] ulong seed, [NativeTypeName("int64_t")] long device, [NativeTypeName("int64_t")] long index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_initial_seed", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Generator_initial_seed([NativeTypeName("const Generator")] OpaqueGenerator* gen);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSGenerator_dispose", ExactSpelling = true)]
	public static extern void Generator_dispose([NativeTypeName("const Generator")] OpaqueGenerator* generator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorchCuda_is_available", ExactSpelling = true)]
	public static extern int Cuda_get_IsAvailable();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorchCuda_cudnn_is_available", ExactSpelling = true)]
	public static extern int cuDNN_get_IsAvailable();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorchCuda_device_count", ExactSpelling = true)]
	public static extern int Cuda_get_DeviceCount();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorchCuda_synchronize", ExactSpelling = true)]
	public static extern void Cuda_Synchronize([NativeTypeName("const int64_t")] long device);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cublas_get_allow_tf32", ExactSpelling = true)]
	public static extern bool cuBLAS_get_AllowTF32();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cublas_set_allow_tf32", ExactSpelling = true)]
	public static extern void cuBLAS_set_AllowTF32([NativeTypeName("const bool")] bool flag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cudnn_get_allow_tf32", ExactSpelling = true)]
	public static extern bool cuDNN_get_AllowTF32();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cudnn_set_allow_tf32", ExactSpelling = true)]
	public static extern void cuDNN_set_AllowTF32([NativeTypeName("const bool")] bool flag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_get_allow_fp16_reduced_precision_reduction", ExactSpelling = true)]
	public static extern bool Cuda_get_allow_fp16_reduced_precision_reduction();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_set_allow_fp16_reduced_precision_reduction", ExactSpelling = true)]
	public static extern void Cuda_set_allow_fp16_reduced_precision_reduction([NativeTypeName("const bool")] bool flag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_get_enable_flash_sdp", ExactSpelling = true)]
	public static extern bool Cuda_get_enable_flash_sdp();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_set_enable_flash_sdp", ExactSpelling = true)]
	public static extern void Cuda_set_enable_flash_sdp([NativeTypeName("const bool")] bool flag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_get_enable_math_sdp", ExactSpelling = true)]
	public static extern bool Cuda_get_enable_math_sdp();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSBackend_cuda_set_enable_math_sdp", ExactSpelling = true)]
	public static extern void Cuda_set_enable_math_sdp([NativeTypeName("const bool")] bool flag);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_get_num_threads", ExactSpelling = true)]
	public static extern int Torch_get_num_threads();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_set_num_threads", ExactSpelling = true)]
	public static extern void Torch_set_num_threads([NativeTypeName("const int")] int threads);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_get_num_interop_threads", ExactSpelling = true)]
	public static extern int Torch_get_num_interop_threads();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_set_num_interop_threads", ExactSpelling = true)]
	public static extern void Torch_set_num_interop_threads([NativeTypeName("const int")] int threads);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_get_and_reset_last_err", ExactSpelling = true)]
	[return: NativeTypeName("const char *")]
	public static extern sbyte* Torch_get_and_reset_last_err();

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_can_cast", ExactSpelling = true)]
	public static extern int Torch_can_cast([NativeTypeName("const int")] int type1, [NativeTypeName("const int")] int type2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_promote_types", ExactSpelling = true)]
	public static extern int Torch_promote_types([NativeTypeName("const int")] int type1, [NativeTypeName("const int")] int type2);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_int8_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromInt8([NativeTypeName("int8_t")] sbyte value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_uint8_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromUInt8([NativeTypeName("uint8_t")] byte value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_int16_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromInt16(short value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_int32_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromInt32(int value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_int64_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromInt64([NativeTypeName("long")] int value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_float32_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromSingle(float value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_float64_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromDouble(double value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_bool_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromBoolean(bool value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_float16_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromHalf(float value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_bfloat16_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromBFloat16(float value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_complex32_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromComplex32(float real, float imaginary);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_complex64_to_scalar", ExactSpelling = true)]
	[return: NativeTypeName("Scalar")]
	public static extern OpaqueScalar* Scalar_FromComplex64(double real, double imaginary);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_int8", ExactSpelling = true)]
	[return: NativeTypeName("int8_t")]
	public static extern sbyte Scalar_ToInt8([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_uint8", ExactSpelling = true)]
	[return: NativeTypeName("uint8_t")]
	public static extern byte Scalar_ToUInt8([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_int16", ExactSpelling = true)]
	[return: NativeTypeName("int16_t")]
	public static extern short Scalar_ToInt16([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_int32", ExactSpelling = true)]
	[return: NativeTypeName("int32_t")]
	public static extern int Scalar_ToInt32([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_int64", ExactSpelling = true)]
	[return: NativeTypeName("int64_t")]
	public static extern long Scalar_ToInt64([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_float32", ExactSpelling = true)]
	public static extern float Scalar_ToSingle([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_float64", ExactSpelling = true)]
	public static extern double Scalar_ToDouble([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_bool", ExactSpelling = true)]
	public static extern bool Scalar_ToBoolean([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_float16", ExactSpelling = true)]
	public static extern void Scalar_ToHalf([NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("unsigned short *")] ushort* res);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_complex32", ExactSpelling = true)]
	public static extern void Scalar_ToComplex32([NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("float *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, float*> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_to_complex64", ExactSpelling = true)]
	public static extern void Scalar_ToComplex64([NativeTypeName("Scalar")] OpaqueScalar* value, [NativeTypeName("double *(*)(size_t)")] delegate* unmanaged[Cdecl]<nuint, double*> allocator);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_scalar_type", ExactSpelling = true)]
	[return: NativeTypeName("int8_t")]
	public static extern sbyte Scalar_get_Type([NativeTypeName("Scalar")] OpaqueScalar* value);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSTorch_dispose_scalar", ExactSpelling = true)]
	public static extern void Scalar_dispose([NativeTypeName("Scalar")] OpaqueScalar* scalar);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erf_scalar", ExactSpelling = true)]
	public static extern double Special_erf_scalar([NativeTypeName("const double")] double x);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSSpecial_erfc_scalar", ExactSpelling = true)]
	public static extern double Special_erfc_scalar([NativeTypeName("const double")] double x);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_AdjustHue", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Vision_AdjustHue([NativeTypeName("const Tensor")] OpaqueTensor* img, [NativeTypeName("const double")] double hue_factor);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_GenerateAffineGrid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Vision_GenerateAffineGrid([NativeTypeName("Tensor")] OpaqueTensor* theta, [NativeTypeName("const int64_t")] long w, [NativeTypeName("const int64_t")] long h, [NativeTypeName("const int64_t")] long ow, [NativeTypeName("const int64_t")] long oh);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_ApplyGridTransform", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Vision_ApplyGridTransform([NativeTypeName("Tensor")] OpaqueTensor* i, [NativeTypeName("Tensor")] OpaqueTensor* g, [NativeTypeName("const int8_t")] sbyte m, [NativeTypeName("const float *")] float* fill, [NativeTypeName("const int64_t")] long fill_length);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_PerspectiveGrid", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Vision_PerspectiveGrid([NativeTypeName("const float *")] float* coeffs, [NativeTypeName("const int64_t")] long coeffs_length, [NativeTypeName("const int64_t")] long ow, [NativeTypeName("const int64_t")] long oh, [NativeTypeName("const int8_t")] sbyte scalar_type, [NativeTypeName("const int")] int device_type, [NativeTypeName("const int")] int device_index);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_ScaleChannel", ExactSpelling = true)]
	[return: NativeTypeName("Tensor")]
	public static extern OpaqueTensor* Vision_ScaleChannel([NativeTypeName("Tensor")] OpaqueTensor* ic);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_ComputeOutputSize", ExactSpelling = true)]
	public static extern void Vision_ComputeOutputSize([NativeTypeName("const float *")] float* matrix, [NativeTypeName("const int64_t")] long matrix_length, [NativeTypeName("const int64_t")] long w, [NativeTypeName("const int64_t")] long h, [NativeTypeName("int32_t *")] int* first, [NativeTypeName("int32_t *")] int* second);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_BRGA_RGB", ExactSpelling = true)]
	public static extern void Vision_BRGA_RGB([NativeTypeName("const uint8_t *")] byte* inputBytes, [NativeTypeName("uint8_t *")] byte* redBytes, [NativeTypeName("uint8_t *")] byte* greenBytes, [NativeTypeName("uint8_t *")] byte* blueBytes, [NativeTypeName("int64_t")] long inputChannelCount, [NativeTypeName("int64_t")] long imageSize);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_BRGA_RGBA", ExactSpelling = true)]
	public static extern void Vision_BRGA_RGBA([NativeTypeName("const uint8_t *")] byte* inputBytes, [NativeTypeName("uint8_t *")] byte* redBytes, [NativeTypeName("uint8_t *")] byte* greenBytes, [NativeTypeName("uint8_t *")] byte* blueBytes, [NativeTypeName("uint8_t *")] byte* alphaBytes, [NativeTypeName("int64_t")] long inputChannelCount, [NativeTypeName("int64_t")] long imageSize);

	[DllImport("LibTorchSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "THSVision_RGB_BRGA", ExactSpelling = true)]
	public static extern void Vision_RGB_BRGA([NativeTypeName("const uint8_t *")] byte* inputBytes, [NativeTypeName("uint8_t *")] byte* outBytes, [NativeTypeName("int64_t")] long inputChannelCount, [NativeTypeName("int64_t")] long imageSize);
}
