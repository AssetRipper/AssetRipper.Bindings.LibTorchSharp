namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerDecoder
{
	public unsafe TransformerDecoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation)
	{
		using TransformerDecoderLayer decoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation);
		handle = Create(decoder_layer, num_layers, null);
	}

	public TransformerDecoder(long num_layers, TransformerDecoderLayer decoder_layer) : this(decoder_layer, num_layers)
	{
	}
}
