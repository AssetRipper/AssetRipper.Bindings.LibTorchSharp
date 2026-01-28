namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class TensorIndexTests
{
	[Test]
	public void IndexSingle()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		AssertIndexEqual(0, tensor, TensorIndex.Single(0), TensorIndex.Single(0));
		AssertIndexEqual(1, tensor, TensorIndex.Single(0), TensorIndex.Single(1));
		AssertIndexEqual(2, tensor, TensorIndex.Single(0), TensorIndex.Single(2));
		AssertIndexEqual(6, tensor, TensorIndex.Single(1), TensorIndex.Single(0));
		AssertIndexEqual(5, tensor, TensorIndex.Single(1), TensorIndex.Single(1));
		AssertIndexEqual(4, tensor, TensorIndex.Single(1), TensorIndex.Single(2));

		static void AssertIndexEqual(int expected, Tensor tensor, params ReadOnlySpan<TensorIndex> indices)
		{
			using Tensor result = tensor.Index(indices);
			Assert.That(result.ToValue<int>(), Is.EqualTo(expected));
		}
	}

	[Test]
	public void IndexBoolean()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		using Tensor t1 = tensor.Index([TensorIndex.Boolean(true), TensorIndex.Single(0)]);
		int[,] values1 = t1.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values1.GetLength(0), Is.EqualTo(1));
			Assert.That(values1.GetLength(1), Is.EqualTo(3));
		}
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values1[0, 0], Is.Zero);
			Assert.That(values1[0, 1], Is.EqualTo(1));
			Assert.That(values1[0, 2], Is.EqualTo(2));
		}

		using Tensor t2 = tensor.Index([TensorIndex.Boolean(false), TensorIndex.Single(0)]);
		int[,] values2 = t2.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values2.GetLength(0), Is.Zero);
			Assert.That(values2.GetLength(1), Is.EqualTo(3));
		}
	}

	[Test]
	public void IndexColon()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		using Tensor temp = tensor.Index([TensorIndex.Colon, TensorIndex.Single(0)]);
		int[] values = temp.ToArray<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values[0], Is.Zero);
			Assert.That(values[1], Is.EqualTo(6));
		}
	}

	[Test]
	public void IndexEllipsis()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		using Tensor temp = tensor.Index([TensorIndex.Ellipsis, TensorIndex.Single(0)]);
		int[] values = temp.ToArray<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values[0], Is.Zero);
			Assert.That(values[1], Is.EqualTo(6));
		}
	}

	[Test]
	public void IndexNull()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		using Tensor temp = tensor.Index([TensorIndex.Null, TensorIndex.Single(0)]);
		int[,] values = temp.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values[0, 0], Is.Zero);
			Assert.That(values[0, 1], Is.EqualTo(1));
			Assert.That(values[0, 2], Is.EqualTo(2));
		}
	}

	[Test]
	public void IndexNone()
	{
		using Tensor tensor = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);
		using Tensor temp = tensor.Index([TensorIndex.None, TensorIndex.Single(0)]);
		int[,] values = temp.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values[0, 0], Is.Zero);
			Assert.That(values[0, 1], Is.EqualTo(1));
			Assert.That(values[0, 2], Is.EqualTo(2));
		}
	}

	[Test]
	public void IndexSlice()
	{
		using Tensor i = new Tensor([0, 1, 2, 6, 5, 4], [2, 3]);

		// t1: Slice(0,2) on dim0 and Single(0) on dim1 -> 1D length 2
		using Tensor t1 = i.Index([TensorIndex.Slice(0, 2), TensorIndex.Single(0)]);
		int[] values1 = t1.ToArray<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values1[0], Is.Zero);
			Assert.That(values1[1], Is.EqualTo(6));
		}

		// one slice -> 1D length 1
		using Tensor t2 = i.Index([TensorIndex.Slice(1, 2), TensorIndex.Single(0)]);
		int[] values2 = t2.ToArray<int>();
		Assert.That(values2[0], Is.EqualTo(6));

		// two slice -> 2D shape [1,2]
		using Tensor t3 = i.Index([TensorIndex.Slice(1, 2), TensorIndex.Slice(1, 3)]);
		int[,] values3 = t3.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values3[0, 0], Is.EqualTo(5));
			Assert.That(values3[0, 1], Is.EqualTo(4));
		}

		// slice with step -> 2D shape [1,2]
		using Tensor t4 = i.Index([TensorIndex.Slice(1, 2), TensorIndex.Slice(0, 3, step: 2)]);
		int[,] values4 = t4.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values4[0, 0], Is.EqualTo(6));
			Assert.That(values4[0, 1], Is.EqualTo(4));
		}

		// end absent -> 2D shape [1,2]
		using Tensor t5 = i.Index([TensorIndex.Slice(start: 1), TensorIndex.Slice(start: 1)]);
		int[,] values5 = t5.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values5[0, 0], Is.EqualTo(5));
			Assert.That(values5[0, 1], Is.EqualTo(4));
		}

		// start absent -> 2D shape [1,2]
		using Tensor t6 = i.Index([TensorIndex.Slice(start: 1), TensorIndex.Slice(stop: 2)]);
		int[,] values6 = t6.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values6[0, 0], Is.EqualTo(6));
			Assert.That(values6[0, 1], Is.EqualTo(5));
		}

		// start and end absent (step only) -> 2D shape [1,2]
		using Tensor t7 = i.Index([TensorIndex.Slice(start: 1), TensorIndex.Slice(step: 2)]);
		int[,] values7 = t7.ToArray2D<int>();
		using (Assert.EnterMultipleScope())
		{
			Assert.That(values7[0, 0], Is.EqualTo(6));
			Assert.That(values7[0, 1], Is.EqualTo(4));
		}
	}
}
