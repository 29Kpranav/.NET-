using System;

// Subject interface
interface IImage
{
    void Display();
}

// Real Subject
class RealImage : IImage
{
    private string filename;

    public RealImage(string filename)
    {
        this.filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image: {filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {filename}");
    }
}

// Proxy
class ProxyImage : IImage
{
    private RealImage realImage;
    private string filename;

    public ProxyImage(string filename)
    {
        this.filename = filename;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(filename);
        }
        realImage.Display();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IImage image1 = new ProxyImage("image1.jpg");
        IImage image2 = new ProxyImage("image2.jpg");

        image1.Display(); // Loads and displays image1.jpg
        image1.Display(); // Displays image1.jpg (already loaded)
        image2.Display(); // Loads and displays image2.jpg
    }
}