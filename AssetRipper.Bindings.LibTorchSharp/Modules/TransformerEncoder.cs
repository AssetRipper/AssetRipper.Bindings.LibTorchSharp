namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct TransformerEncoder
{
	public TransformerEncoder(long num_layers, long d_model, long nhead, long dim_feedforward, double dropout, long activation, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		using TransformerEncoderLayer encoder_layer = new(d_model, nhead, dim_feedforward, dropout, activation, dtype, device);
		handle = new TransformerEncoder(encoder_layer, num_layers, dtype, device);
	}

	public TransformerEncoder(long num_layers, TransformerEncoderLayer encoder_layer, ScalarType dtype = ScalarType.Float32, Device? device = null) : this(encoder_layer, num_layers, dtype, device)
	{
	}
}
