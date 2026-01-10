using AssetRipper.Bindings.LibTorchSharp.Optimizers;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class OptimizerTests
{
	[Test]
	public void SGDStep()
	{
		using Tensor parameter = new([1f], requires_grad: true);
		using SGD optimizer = CreateSGD(parameter);
		using Tensor loss = parameter.Abs();
		loss.Backward();
		optimizer.Step();
		optimizer.ZeroGrad();
		float value = parameter.ToValue<float>();
		Assert.That(value, Is.LessThan(1f));
	}

	private static SGD CreateSGD(params ReadOnlySpan<Tensor> parameters)
	{
		return new SGD(parameters, 0.1f, default, default, default, default);
	}
}
