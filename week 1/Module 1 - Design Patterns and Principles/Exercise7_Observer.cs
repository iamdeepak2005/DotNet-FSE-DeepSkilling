using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    // observer interface
    public interface IObserver
    {
        void Update(double price);
    }

    // subject interface
    public interface IStockMarket
    {
        void Register(IObserver observer);
        void Notify();
    }

    // stock market implementation
    public class StockMarket : IStockMarket
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                Notify();
            }
        }

        public void Register(IObserver observer) => _observers.Add(observer);
        public void Notify()
        {
            foreach (var obs in _observers)
            {
                obs.Update(_price);
            }
        }
    }

    // concrete observers
    public class MobileApp : IObserver
    {
        public void Update(double price) => Console.WriteLine($"[Mobile App] stock price alert: ${price}");
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- observer design pattern test ---");

            StockMarket market = new StockMarket();
            MobileApp userApp = new MobileApp();

            market.Register(userApp);

            // update triggers notifications
            market.Price = 120.50;
            market.Price = 125.75;
        }
    }
}