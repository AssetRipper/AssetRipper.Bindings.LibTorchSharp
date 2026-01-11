using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly partial struct MultiheadAttention
{
	[DebuggerHidden]
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	[StackTraceHidden]
	public Tensor Forward(Tensor query, Tensor key, Tensor value, Tensor key_padding_mask, Tensor attn_mask)
	{
		Forward(query, key, value, key_padding_mask, false, attn_mask, out Tensor result, out Tensor weights);
		Debug.Assert(weights.IsNull);
		return result;
	}
}
