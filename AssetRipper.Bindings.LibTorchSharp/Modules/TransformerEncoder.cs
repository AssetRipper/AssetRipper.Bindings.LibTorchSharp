namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerEncoder
{
	public unsafe TransformerEncoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation)
	{
		using TransformerEncoderLayer encoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation);
		handle = Create(encoder_layer, num_layers, null);
	}

	public TransformerEncoder(long num_layers, TransformerEncoderLayer encoder_layer) : this(encoder_layer, num_layers)
	{
	}
}
