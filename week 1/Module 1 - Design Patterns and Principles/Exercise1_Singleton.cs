using System;

namespace DesignPatterns.Singleton
{
    // singleton logger class to log events
    // deepa nair - cognizant dot-net training
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        // private constructor so no one can do 'new Logger()'
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        // double checked lock to make it thread safe
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[Log]: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- singleton design pattern test ---");
            
            // grab the instances
            Logger l1 = Logger.Instance;
            Logger l2 = Logger.Instance;

            l1.Log("testing action 1");
            l2.Log("testing action 2");

            // verify they are same
            if (ReferenceEquals(l1, l2))
            {
                Console.WriteLine("Success: Both references point to the same logger instance!");
            }
        }
    }
}