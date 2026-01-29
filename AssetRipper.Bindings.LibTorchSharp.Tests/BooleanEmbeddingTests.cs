using AssetRipper.Bindings.LibTorchSharp.Modules;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class BooleanEmbeddingTests
{
	[Theory]
	public void ForwardCreatesHigherDimensionalTensor([Range(0, 6)] int dimensions)
	{
		using BooleanEmbedding embedding = new(3, ScalarType.Float32, default);
		long[] shape = new long[dimensions];
		Array.Fill(shape, 1);
		using Tensor input = Tensor.Zeros(shape, ScalarType.Bool, false);
		using Tensor output = embedding.Forward(input);
		Assert.That(output.Ndimension(), Is.EqualTo(dimensions + 1));
	}

	[Test]
	public void ForwardGivesCorrectValues()
	{
		using BooleanEmbedding embedding = new(Tensor.Ones([1], ScalarType.Float32, true), Tensor.Zeros([1], ScalarType.Float32, true));
		using Tensor trueBoolean = new(true);
		using Tensor falseBoolean = new(false);
		using Tensor trueOutput = embedding.Forward(trueBoolean);
		using Tensor falseOutput = embedding.Forward(falseBoolean);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(trueOutput.ToValue<float>(), Is.EqualTo(1.0f));
			Assert.That(falseOutput.ToValue<float>(), Is.Zero);
		}
	}

	[Test]
	public void GradIsNotZero()
	{
		using BooleanEmbedding embedding = new(Tensor.Ones([1], ScalarType.Float32, true), Tensor.Zeros([1], ScalarType.Float32, true));
		using Tensor booleans = new([true, false]);

		using Tensor output = embedding.Forward(booleans);

		// Target 0.5 for both true and false outputs
		using Tensor target = new([0.5f, 0.5f]);
		using Tensor loss = NN.MseLoss(output, target, Reduction.Mean);

		loss.Backward();

		using Tensor trueEmbedding = embedding.TrueEmbedding;
		using Tensor trueGrad = trueEmbedding.Grad;
		using Tensor trueGradNorm = trueGrad.Norm(2);
		float trueGradNormValue = trueGrad.ToValue<float>();

		using Tensor falseEmbedding = embedding.FalseEmbedding;
		using Tensor falseGrad = falseEmbedding.Grad;
		using Tensor falseGradNorm = falseGrad.Norm(2);
		float falseGradNormValue = falseGrad.ToValue<float>();

		using (Assert.EnterMultipleScope())
		{
			Assert.That(trueGradNormValue, Is.Not.Zero);
			Assert.That(falseGradNormValue, Is.Not.Zero);
		}
	}
}
