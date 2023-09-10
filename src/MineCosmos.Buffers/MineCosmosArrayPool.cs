using System.Buffers;

namespace MineCosmos.Buffers;

public class MineCosmosArrayPool
{
    private static readonly ArrayPool<byte> ArrayPool;
    static MineCosmosArrayPool()
    {
        ArrayPool = ArrayPool<byte>.Create();
    }

    public static byte[] Rent(int minimumLength)
    {
        return ArrayPool.Rent(minimumLength);
    }

    public static void Return(byte[] array, bool clearArray = false)
    {
        ArrayPool.Return(array, clearArray);
    }
}
