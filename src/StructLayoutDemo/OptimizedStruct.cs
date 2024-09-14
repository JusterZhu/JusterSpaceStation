using System.Runtime.InteropServices;

namespace StructLayoutDemo;

[StructLayout(LayoutKind.Sequential)]
public struct OptimizedStruct
{
    public int Field1;
    public short Field2;
    public byte Field3; // 放在最后以减少填充
}