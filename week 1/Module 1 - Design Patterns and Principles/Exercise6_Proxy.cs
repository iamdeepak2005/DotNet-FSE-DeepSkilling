using System;

namespace DesignPatterns.Proxy
{
    // image interface
    public interface IImage
    {
        void Display();
    }

    // heavy class loading image from disk
    public class RealImage : IImage
    {
        private readonly string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk() => Console.WriteLine($"loading image {_fileName} from server (heavy task)...");

        public void Display() => Console.WriteLine($"displaying {_fileName}");
    }

    // proxy class that caches instance
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private readonly string _fileName;

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_fileName); // lazy load
            }
            _realImage.Display();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- proxy design pattern test ---");

            IImage img = new ProxyImage("chart.png");
            
            // first call will trigger load from server
            Console.WriteLine("Calling display 1st time:");
            img.Display();

            // second call will skip load
            Console.WriteLine("\nCalling display 2nd time:");
            img.Display();
        }
    }
}