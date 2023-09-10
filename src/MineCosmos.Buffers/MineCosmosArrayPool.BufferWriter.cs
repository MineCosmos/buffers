namespace MineCosmos.Buffers;

ref partial struct BufferWriter
{
    private Span<byte> _buffer;

    public BufferWriter(Span<byte> buffer)
    {
        _buffer = buffer;
        WrittenCount = 0;
        BeforeCodingWrittenPosition = 0;
    }

    public Span<byte> Free => _buffer.Slice(WrittenCount);
    public Span<byte> Written => _buffer.Slice(0, WrittenCount);

    public int BeforeCodingWrittenPosition { get; internal set; }

    public int WrittenCount { get; private set; }

    public void Advance(int count)
    {
        WrittenCount += count;
    }
}