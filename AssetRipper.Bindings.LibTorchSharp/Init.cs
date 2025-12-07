namespace AssetRipper.Bindings.LibTorchSharp;

public static partial class Init
{
	public static (long fanIn, long fanOut) CalculateFanInAndFanOut(Tensor tensor)
	{
		long dimensions = tensor.Ndimension();

		if (dimensions < 2)
		{
			throw new ArgumentException("Fan in and fan out can not be computed for tensor with fewer than 2 dimensions");
		}

		long[] shape = tensor.Sizes();

		// Linear
		if (dimensions == 2)
		{
			return (shape[1], shape[0]);
		}
		else
		{
			long numInputFMaps = shape[1];
			long numOutputFMaps = shape[0];
			long receptiveFieldSize = tensor[0, 0].Numel();

			return (numInputFMaps * receptiveFieldSize, numOutputFMaps * receptiveFieldSize);
		}
	}
}
