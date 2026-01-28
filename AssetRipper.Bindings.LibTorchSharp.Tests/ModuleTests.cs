using AssetRipper.Bindings.LibTorchSharp.Modules;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class ModuleTests
{
	[Test]
	public void Embedding_Forward()
	{
		Assert.DoesNotThrow(() =>
		{
			using Embedding embedding = new(1, 1, -1, false, default, false, 2.0, false, false);
			using Tensor input = new([0]);
			using Tensor output = embedding.Forward(input);
		});
	}

	[Test]
	public void Embedding_ForwardInSequential()
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
	public void TransformerEncoderLayer_Save()
	{
		using MemoryStream stream = new();
		using TransformerEncoderLayer layer = new(8, 2, 16, 0.1, 0);
		{
			using StateDictionary state1 = new();
			state1.CopyFrom(layer);
			state1.Save(stream);
		}
		Assert.That(stream.Length, Is.GreaterThan(0));
	}

	[Test]
	public void MultiheadAttentionHasParameters()
	{
		using MultiheadAttention attention = new(8, 2, default, false, false, false, 8, 8);
		Tensor[] parameters = attention.GetParameters(true);
		try
		{
			Assert.That(parameters, Is.Not.Empty);
		}
		finally
		{
			parameters.DisposeAllAndClear();
		}
	}

	[Test]
	public void Linear_SaveAndLoad()
	{
		using MemoryStream stream = new();
		using Linear linear1 = new(Tensor.Ones([2], ScalarType.Float32, true), Tensor.Zeros([2], ScalarType.Float32, true));
		linear1.Save(stream);
		stream.Position = 0;

		using StateDictionary state = StateDictionary.Load(stream);
		using Linear linear2 = new(state);

		using (Assert.EnterMultipleScope())
		{
			using Tensor weights1 = linear1.Weights;
			using Tensor weights2 = linear2.Weights;
			using Tensor bias1 = linear1.Bias;
			using Tensor bias2 = linear2.Bias;
			Assert.That(weights2.ToArray<float>(), Is.EquivalentTo(weights1.ToArray<float>()));
			Assert.That(bias2.ToArray<float>(), Is.EquivalentTo(bias1.ToArray<float>()));
		}
	}

	[Test]
	public void Linear_SaveAndLoadWithNullTensor()
	{
		using MemoryStream stream = new();
		using Linear linear1 = new(Tensor.Ones([2], ScalarType.Float32, true), Tensor.Null);
		linear1.Save(stream);
		stream.Position = 0;

		using StateDictionary state = StateDictionary.Load(stream);
		using Linear linear2 = new(state);

		using (Assert.EnterMultipleScope())
		{
			using Tensor weights1 = linear1.Weights;
			using Tensor weights2 = linear2.Weights;
			using Tensor bias2 = linear2.Bias;
			Assert.That(weights2.ToArray<float>(), Is.EquivalentTo(weights1.ToArray<float>()));
			Assert.That(bias2.IsNull);
		}
	}
}
