using AssetRipper.Bindings.LibTorchSharp.Modules;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class ModuleTests
{
	[Test]
	public void EmbeddingForward()
	{
		Assert.DoesNotThrow(() =>
		{
			using Embedding embedding = new(1, 1, -1, false, default, false, 2.0, false, false);
			using Tensor input = new([0]);
			using Tensor output = embedding.Forward(input);
		});
	}

	[Test]
	public void EmbeddingForwardInSequential()
	{
		Assert.DoesNotThrow(() =>
		{
			using NNAnyModule embedding = Embedding.CreateAsAnyModule(1, 1, -1, false, default, false, 2.0, false, false);
			using Sequential sequential = new();
			unsafe
			{
				fixed (byte* namePtr = "Embedding"u8)
				{
					sequential.PushBack((sbyte*)namePtr, embedding);
				}
			}
			using Tensor input = new([0]);
			using Tensor output = sequential.Forward(input);
		});
	}

	[Test]
	public void LinearSaveAndLoad()
	{
		using MemoryStream stream = new();
		using Linear linear1 = new(Tensor.Ones([2], ScalarType.Float32, true), Tensor.Zeros([2], ScalarType.Float32, true));
		linear1.Save(stream);
		stream.Position = 0;

		using StateDictionary state = StateDictionary.Load(stream);
		using Linear linear2 = new(state);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(linear2.weights.ToArray<float>(), Is.EquivalentTo(linear1.weights.ToArray<float>()));
			Assert.That(linear2.bias.ToArray<float>(), Is.EquivalentTo(linear1.bias.ToArray<float>()));
		}
	}

	[Test]
	public void LinearSaveAndLoadWithNullTensor()
	{
		using MemoryStream stream = new();
		using Linear linear1 = new(Tensor.Ones([2], ScalarType.Float32, true), Tensor.Null);
		linear1.Save(stream);
		stream.Position = 0;

		using StateDictionary state = StateDictionary.Load(stream);
		using Linear linear2 = new(state);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(linear2.weights.ToArray<float>(), Is.EquivalentTo(linear1.weights.ToArray<float>()));
			Assert.That(linear2.bias.IsNull);
		}
	}
}
