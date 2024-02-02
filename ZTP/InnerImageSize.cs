namespace ZTP;

public struct InnerImageSize
{
    public int xStart { get; set; }
    public int xEnd { get; set; }
    public int yStart { get; set; }
    public int yEnd { get; set; }

    public InnerImageSize(int xStart, int xEnd, int yStart, int yEnd)
    {
        this.xStart = xStart;
        this.xEnd = xEnd;
        this.yStart = yStart;
        this.yEnd = yEnd;
    }
}