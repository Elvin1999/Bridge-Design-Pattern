using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Window
    {
        public Window(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
        public void Show()
        {
            Console.WriteLine($" |Title| {Title}");
            Console.WriteLine($"Background {GetCurrentBackground()}");
        }
        public string GetCurrentBackground()
        {
            return MyBackground.GetBackground();
        }
        public Background MyBackground { get; set; }
        public void Setbackground(Background background)
        {
            MyBackground = background;
        }
    }

    interface Background
    {
        string GetBackground();
    }

    class Image
    {
        public Image(string path, double width, double height, string content)
        {
            Path = path;
            Width = width;
            Height = height;
            Content = content;
        }

        public string Path { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Content { get; set; }
    }

    class ImageBackground : Background
    {
        public ImageBackground(Image myImage)
        {
            MyImage = myImage;
        }
        public Image MyImage { get; set; }
        public void SetImage(Image image)
        {
            MyImage = image;
        }
        public string GetBackground()
        {
            return MyImage.Content;
        }
    }
    class ColorBackground : Background
    {
        public ColorBackground(string color)
        {
            Color = color;
        }

        public string Color { get; set; }
        public void SetColor(string color)
        {
            Color = color;
        }
        public string GetBackground()
        {
            return Color;
        }
    }
    class Controller
    {
        public void Run()
        {
            ColorBackground color = new ColorBackground("Red");
            Image i = new Image("data.json", 100, 100, "ImageMause");
            ImageBackground background = new ImageBackground(i);
            Window window = new Window("My Window1");
            Window window2 = new Window("My Window2");
            window.Setbackground(color);
            window.Show();
            color.SetColor("Yellow");
            window2.Setbackground(color);
            window2.Show();
            color.SetColor("Green");
            window2.Setbackground(color);
            window2.Show();
            window2.Setbackground(background);
            window2.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Run();
        }
    }
}
