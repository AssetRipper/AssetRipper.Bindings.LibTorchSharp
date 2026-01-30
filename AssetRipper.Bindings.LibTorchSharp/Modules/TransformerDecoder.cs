namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerDecoder
{
	public TransformerDecoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		using TransformerDecoderLayer decoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation, dtype, device);
		handle = new TransformerDecoder(decoder_layer, num_layers, dtype, device);
	}

	public TransformerDecoder(long num_layers, TransformerDecoderLayer decoder_layer, ScalarType dtype = ScalarType.Float32, Device? device = null) : this(decoder_layer, num_layers, dtype, device)
	{
	}
}
