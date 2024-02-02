// See https://aka.ms/new-console-template for more information

namespace ZTP;

internal class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Podaj nazwę pliku wejściowego i pliku wejściowego po spacji");
        }
        
        if (string.IsNullOrEmpty(args[0]))
        {
            throw new ArgumentException("Nie podano nazwy pliku wejściowego");
        }

        if (string.IsNullOrEmpty(args[1]))
        {
            throw new ArgumentException("Nie podano nazwy pliku wyjściowego");
        }

        if (!File.Exists($"./{args[0]}"))
        {
            throw new ArgumentException("Plik nie istnieje");
        }
        
        var file = new ImageFile();

        var image = file.LoadImage(args[0]);

        var part1 = new InnerImageSize(0, image.Width / 2, 0, image.Height/2);

        var image2 = Image.IncreaseRatio(image, part1,  new[] { 1f, 1.5f, 1f });
        
        var part2 = new InnerImageSize(0, image.Width / 2, image.Height/2, image.Height);

        image2 = Image.IncreaseRatio(image2, part2,  new[] { 1.5f, 1f, 1f });
        
        var part3 = new InnerImageSize(image.Width/2, image.Width, image.Height/2, image.Height);

        image2 = Image.IncreaseRatio(image2, part3,  new[] { 1f, 1f, 1.5f });
        
        var part4 = new InnerImageSize(image.Width/2, image.Width, 0, image.Height/2);

        image2 = Image.IncreaseRatio(image2, part4,  new[] { .5f, .5f, .5f });

        if (image2 == null)
        {
            throw new ArgumentException("Nie udało się przetworzyć obrazu");
        }
        
        file.SaveImage(image2, args[1]);
    }
}