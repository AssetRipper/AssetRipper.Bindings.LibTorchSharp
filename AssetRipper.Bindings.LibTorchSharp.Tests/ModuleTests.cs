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
			using Tensor output = embedding.forward(input);
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
					sequential.push_back((sbyte*)namePtr, embedding);
				}
			}
			using Tensor input = new([0]);
			using Tensor output = sequential.forward(input);
		});
	}
}
