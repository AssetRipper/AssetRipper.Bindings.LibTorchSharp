namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerDecoder
{
	public unsafe TransformerDecoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation, Device? device = null)
	{
		using TransformerDecoderLayer decoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation, device);
		handle = Create(decoder_layer, num_layers, null);
		handle.ToDevice(false, device);
	}

	public TransformerDecoder(long num_layers, TransformerDecoderLayer decoder_layer, Device? device = null) : this(decoder_layer, num_layers, device)
	{
	}
}
