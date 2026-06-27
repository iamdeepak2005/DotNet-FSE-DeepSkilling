using System;

namespace DesignPatterns.Strategy
{
    // strategy interface
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // concrete strategies
    public class CreditCardPayment(string name) : IPaymentStrategy
    {
        public void Pay(double amount) => Console.WriteLine($"Paid ${amount} using Credit Card for {name}");
    }

    public class PayPalPayment(string email) : IPaymentStrategy
    {
        public void Pay(double amount) => Console.WriteLine($"Paid ${amount} using PayPal account: {email}");
    }

    // payment context
    public class CheckoutContext
    {
        private IPaymentStrategy _strategy;

        public void SetStrategy(IPaymentStrategy strategy) => _strategy = strategy;

        public void Process(double amount)
        {
            if (_strategy == null) throw new InvalidOperationException("Strategy not set!");
            _strategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- strategy design pattern test ---");

            CheckoutContext ctx = new CheckoutContext();
            
            ctx.SetStrategy(new PayPalPayment("deepa@test.com"));
            ctx.Process(75.50);

            ctx.SetStrategy(new CreditCardPayment("Deepa Nair"));
            ctx.Process(100.00);
        }
    }
}