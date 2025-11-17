namespace AssetRipper.Bindings.LibTorchSharp;

/// <summary>
/// The element types of tensors.
/// </summary>
public enum ScalarType : sbyte
{
	Byte = 0,
	Int8 = 1,
	Int16 = 2,
	Int32 = 3,
	Int64 = 4,
	Float16 = 5,
	Float32 = 6,
	Float64 = 7,
	//ComplexFloat16 = 8,
	ComplexFloat32 = 9,
	ComplexFloat64 = 10,
	Bool = 11,
	//QInt8 = 12,
	//QUInt8 = 13,
	//QUInt32 = 14,
	BFloat16 = 15
}
