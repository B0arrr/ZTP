using System.Drawing;

namespace ZTP;

public class Matrix
{
    private readonly Color[,] _data;

    public int Width { get; }
    public int Height { get; }

    public Matrix(int width, int height)
    {
        Width = width;
        Height = height;
        _data = new Color[Width, Height];
    }

    public Color this[int row, int column]
    {
        get { return _data[row, column]; }
        set { _data[row, column] = value; }
    }

    public void SetValue(int row, int column, Color value)
    {
        _data[row, column] = value;
    }

    public Color GetValue(int row, int column)
    {
        return _data[row, column];
    }
}
