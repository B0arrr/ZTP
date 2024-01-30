// See https://aka.ms/new-console-template for more information

namespace ZTP;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{args.Length}");
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }
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

        var image2 = Image.IncreaseRatio(image, new[] { 1f, 1.5f, 1f });

        if (image2 == null)
        {
            throw new ArgumentException("Nie udało się przetworzyć obrazu");
        }
        
        file.SaveImage(image2, args[1]);
    }
}