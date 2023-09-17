using System.Runtime.InteropServices;

namespace MineCosmos.Buffers;

[StructLayout(LayoutKind.Sequential)]
public struct HalfByte
{
    private bool _b0;
    private bool _b1;
    private bool _b2;
    private bool _b3;

    public HalfByte(byte value)
    {
        _b0 = (byte)(value & 0000_0001) > 0;
        _b1 = (byte)(value & 0000_0010) > 0;
        _b2 = (byte)(value & 0000_0100) > 0;
        _b3 = (byte)(value & 0000_1000) > 0;
    }

    public byte Value => GetValue();

    private byte GetValue()
    {
        byte result = 0;

        result = _b0 ? (byte)(result | 0000_0001) : result;
        result = _b1 ? (byte)(result | 0000_0010) : result;
        result = _b2 ? (byte)(result | 0000_0100) : result;
        result = _b3 ? (byte)(result | 0000_1000) : result;

        return result;
    }
}
