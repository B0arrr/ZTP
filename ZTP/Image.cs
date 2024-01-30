using System.Drawing;

namespace ZTP;

public class Image
{
    public static Matrix? IncreaseRatio(Matrix colorMatrix, float[] ratio)
        //int xStart, int xEnd, int yStart, int yEnd, float[] ratio)
    {
        var output = new Matrix(colorMatrix.Width, colorMatrix.Height);
        
        if (ratio.Length != 3)
        {
            throw new ArgumentException("Podano złe ratio");
        }

        // Przeprowadź transformację kolorów pikseli
        for (int x = 0; x < colorMatrix.Width; x++)
        {
            for (int y = 0; y < colorMatrix.Height; y++)
            {
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