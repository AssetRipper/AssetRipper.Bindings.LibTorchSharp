using AssetRipper.Bindings.LibTorchSharp.Optimizers;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class OptimizerTests
{
	[Test]
	public void SGDStep()
	{
		using Tensor parameter = new([1f], requires_grad: true);
		using SGD optimizer = CreateSGD(parameter);
		using Tensor loss = parameter.abs();
		loss.backward();
		optimizer.step();
		optimizer.zero_grad();
		float value = parameter.ToValue<float>();
		Assert.That(value, Is.LessThan(1f));
	}

	private static SGD CreateSGD(Tensor parameter)
	{
		return new SGD([parameter], 0.1f, default, default, default, default);
	}
}
