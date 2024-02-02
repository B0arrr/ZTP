using System.Drawing;

namespace ZTP;

public class Image
{
    public static Matrix? IncreaseRatio(Matrix colorMatrix, InnerImageSize size, float[] ratio)
    {
        var output = new Matrix(colorMatrix.Width, colorMatrix.Height);
        
        if (ratio.Length != 3)
        {
            throw new ArgumentException("Podano złe ratio");
        }

        if (size.xStart < 0 || size.xStart > colorMatrix.Width)
        {
            throw new ArgumentException("Początkowe x jest nieprawidłowe");
        }
        
        if (size.yStart < 0 || size.yStart > colorMatrix.Height)
        {
            throw new ArgumentException("Początkowe y jest nieprawidłowe");
        }

        if (size.xEnd < size.xStart || size.xEnd > colorMatrix.Width)
        {
            throw new ArgumentException("Końcowe x jest nieprawidłowe");
        }
        
        if (size.yEnd < size.yStart || size.yEnd > colorMatrix.Height)
        {
            throw new ArgumentException("Końcowe y jest nieprawidłowe");
        }

        // Przeprowadź transformację kolorów pikseli
        for (int x = 0; x < colorMatrix.Width; x++)
        {
            for (int y = 0; y < colorMatrix.Height; y++)
            {
                if ((x >= size.xStart && x < size.xEnd) || (y >= size.yStart && y < size.yEnd))
                {
                    output[x, y] = colorMatrix[x, y];
                    continue;
                }
                
                Color originalColor = colorMatrix[x, y];

                var newRed = (int)(originalColor.R * ratio[0]);
                var newGreen = (int)(originalColor.G * ratio[1]);
                var newBlue = (int)(originalColor.B * ratio[2]);

                newRed = Math.Min(newRed, 255);
                newGreen = Math.Min(newGreen, 255);
                newBlue = Math.Min(newBlue, 255);
                
                output[x, y] = Color.FromArgb(newRed, newGreen, newBlue);
            }
        }

        return output;
    }
}