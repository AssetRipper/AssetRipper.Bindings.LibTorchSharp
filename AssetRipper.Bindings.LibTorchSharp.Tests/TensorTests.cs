namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class TensorTests
{
	[Test]
	public void Ones()
	{
		using Tensor tensor = Tensor.ones([3], ScalarType.Float32, false);
		float[] values = tensor.ToArray<float>();
		Assert.That(values, Is.EquivalentTo([1f, 1f, 1f]));
	}

	[Test]
	public void ScalarMultiplication()
	{
		using Tensor tensor1 = new([1f, 2f]);
		using Tensor tensor2 = tensor1 * 1.5f;
		float[] values = tensor2.ToArray<float>();
		Assert.That(values, Is.EquivalentTo([1.5f, 3f]));
	}

	[Test]
	public void TensorComparison()
	{
		using Tensor tensor1 = new([1f, 2f, 3f]);
		using Tensor tensor2 = new([1.5f, 2f, 2f]);
		using Tensor tensor3 = tensor1 > tensor2;
		bool[] values = tensor3.ToArray<bool>();
		Assert.That(values, Is.EquivalentTo([false, false, true]));
	}

	[Test]
	public void ScalarModuloTensor()
	{
		using Tensor tensor1 = new([1, 4]);
		using Tensor tensor2 = 6 % tensor1;
		int[] values = tensor2.ToArray<int>();
		Assert.That(values, Is.EquivalentTo([0, 2]));
	}

	[Test]
	public void TensorDivideScalar()
	{
		using Tensor tensor1 = new([1f, 4f]);
		using Tensor tensor2 = tensor1 / 2;
		float[] values = tensor2.ToArray<float>();
		Assert.That(values, Is.EquivalentTo([0.5f, 2f]));
	}

	[Test]
	public void IntegerLeftShift()
	{
		using Tensor tensor1 = new([1, 4]);
		using Tensor tensor2 = tensor1 << 1;
		int[] values = tensor2.ToArray<int>();
		Assert.That(values, Is.EquivalentTo([2, 8]));
	}

	[Test]
	public void IntegerSignedRightShift()
	{
		using Tensor tensor1 = new([-1, -1]);
		using Tensor tensor2 = tensor1 >> 31;
		int[] values = tensor2.ToArray<int>();
		Assert.That(values, Is.EquivalentTo([-1, -1]));
	}

	[Test]
	public void IntegerUnsignedRightShift()
	{
		using Tensor tensor1 = new([-1, -1]);
		using Tensor tensor2 = tensor1 >>> 31;
		int[] values = tensor2.ToArray<int>();
		Assert.That(values, Is.EquivalentTo([1, 1]));
	}
}
