namespace AssetRipper.Bindings.LibTorchSharp.Modules;

/// <summary>
/// Represents a module that takes a single input tensor and produces an output tensor.
/// </summary>
public interface IUnaryModule : IModule
{
	/// <summary>
	/// Performs a forward pass of the module with the given input tensor.
	/// </summary>
	/// <param name="input">The input tensor to the module.</param>
	/// <returns>The output tensor resulting from the forward pass.</returns>
	Tensor Forward(Tensor input);
}
