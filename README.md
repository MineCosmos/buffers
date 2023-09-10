# MineCosmos.Buffers

用法:

```csharp
// Reader
var reader = new MinCosmosReader(buffer);
reader.ReadByte();
reader.ReadUInt16();
``````

```csharp
// Writer
var buffer = MinCosmosArrayPool.Rent(minBufferSize: 4096);
try
{
    var writer = new MinCosmosWriter(buffer);
    writer.WriteByte(0);
    writer.WriteUInt16(0);

    var res = writer.FlushAndGetEncodingArray();
}
finally
{
    MinCosmosArrayPool.Return(buffer);
}

```

封装:

```csharp
public interface IMessage
{
    byte[] Decode(ref MineCosmosWriter writer);
}


public class Message: IMessage
{
    public int Age {get; set;}

    public byte[] Decode(ref MineCosmosWriter writer)
    {
        writer.WriterUInt32(Age);
    }
}

public static class MessageConvert
{
    public static byte[] Serialize(this IMessage message, int minBufferSize = 4096)
    {
        byte[] buffer = MinCosmosArrayPool.Rent(minBufferSize);
        try
        {
            MinCosmosWriter writer = new MinCosmosWriter(buffer);
            message.Decode(writer);
            return writer.FlushAndGetEncodingArray();
        }
        finally
        {
            MinCosmosArrayPool.Return(buffer);
        }
    }
}

// result
byte[] result = message.Serialize();

```
