namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerEncoder
{
	public unsafe TransformerEncoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation, Device? device = null)
	{
		using TransformerEncoderLayer encoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation, device);
		handle = Create(encoder_layer, num_layers, null);
		handle.ToDevice(false, device);
	}

	public TransformerEncoder(long num_layers, TransformerEncoderLayer encoder_layer, Device? device = null) : this(encoder_layer, num_layers, device)
	{
	}
}
