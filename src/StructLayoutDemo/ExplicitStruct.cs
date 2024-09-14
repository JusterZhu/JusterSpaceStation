using System.Runtime.InteropServices;

namespace StructLayoutDemo;

[StructLayout(LayoutKind.Explicit)]
public struct ExplicitStruct
{
    [FieldOffset(0)]
    public int Field1;
    [FieldOffset(4)]
    public short Field2;
    [FieldOffset(6)]
    public byte Field3;
}