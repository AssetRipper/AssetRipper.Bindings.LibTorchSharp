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
			Assert.That(linear2.Weights.ToArray<float>(), Is.EquivalentTo(linear1.Weights.ToArray<float>()));
			Assert.That(linear2.Bias.ToArray<float>(), Is.EquivalentTo(linear1.Bias.ToArray<float>()));
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
			Assert.That(linear2.Weights.ToArray<float>(), Is.EquivalentTo(linear1.Weights.ToArray<float>()));
			Assert.That(linear2.Bias.IsNull);
		}
	}

	[Theory]
	public void BooleanEmbedding_ForwardCreatesHigherDimensionalTensor([Range(0, 6)] int dimensions)
	{
		using BooleanEmbedding embedding = new(3, ScalarType.Float32, default);
		long[] shape = new long[dimensions];
		Array.Fill(shape, 1);
		using Tensor input = Tensor.Zeros(shape, ScalarType.Bool, false);
		using Tensor output = embedding.Forward(input);
		Assert.That(output.Ndimension(), Is.EqualTo(dimensions + 1));
	}

	[Test]
	public void BooleanEmbedding_ForwardGivesCorrectValues()
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
}
