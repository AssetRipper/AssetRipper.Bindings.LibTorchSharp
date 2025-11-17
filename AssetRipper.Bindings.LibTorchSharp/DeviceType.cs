namespace AssetRipper.Bindings.LibTorchSharp;

/// <summary>
/// The LibTorch device types.
/// </summary>
/// <remarks>TorchSharp currently only supports CPU and CUDA.</remarks>
public enum DeviceType
{
	CPU = 0,
	CUDA = 1, // CUDA.
	MKLDNN = 2, // Reserved for explicit MKLDNN
	OPENGL = 3, // OpenGL
	OPENCL = 4, // OpenCL
	IDEEP = 5, // IDEEP.
	HIP = 6, // AMD HIP
	FPGA = 7, // FPGA
	MSNPU = 8, // MSNPU
	XLA = 9, // XLA / TPU
	MPS = 13, // Apple Silicon
	META = 14,
}
