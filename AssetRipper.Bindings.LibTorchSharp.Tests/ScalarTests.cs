using System.Numerics;

namespace AssetRipper.Bindings.LibTorchSharp.Tests;

public class ScalarTests
{
	[Test]
	public void Complex32RoundTrip()
	{
		Complex32 original = new(1.5f, -2.5f);
		using Scalar scalar = Scalar.FromComplex32(original);
		Complex32 converted = scalar.ToComplex32();
		Assert.That(converted, Is.EqualTo(original));
	}

	[Test]
	public void Complex64RoundTrip()
	{
		Complex original = new(1.5, -2.5);
		using Scalar scalar = Scalar.FromComplex64(original);
		Complex converted = scalar.ToComplex64();
		Assert.That(converted, Is.EqualTo(original));
	}

	[Test]
	public void IntegerToBooleanConversion()
	{
		using Scalar scalar = Scalar.FromInt32(1);
		Assert.That(scalar.ToBoolean(), Is.True);
	}

	[Test]
	public void IntegerToSingleConversion()
	{
		using Scalar scalar = Scalar.FromInt32(1);
		Assert.That(scalar.ToSingle(), Is.EqualTo(1f));
	}

	[Test]
	public void IntegerToBFloat16Conversion()
	{
		using Scalar scalar = Scalar.FromInt32(1);
		Assert.That((float)scalar.ToBFloat16(), Is.EqualTo(1f));
	}
}
