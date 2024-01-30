using System.Drawing;

namespace ZTP;

public class ImageFile
{
    public Matrix LoadImage(string filePath)
    {
        try
        {
            using var image = new Bitmap(filePath);
            int width = image.Width;
            int height = image.Height;

            Matrix matrix = new Matrix(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    matrix.SetValue(i, j, pixelColor);
                }
            }

            return matrix;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas wczytywania obrazu: " + ex.Message);
            return null;
        }
    }

    public void SaveImage(Matrix matrix, string filePath)
    {
        try
        {
            int width = matrix.Width;
            int height = matrix.Height;

            using var image = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    image.SetPixel(i, j, matrix[i, j]);
                }
            }

            image.Save(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas zapisywania obrazu: " + ex.Message);
        }
    }
}