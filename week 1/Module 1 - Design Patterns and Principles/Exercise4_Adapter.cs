using System;

namespace DesignPatterns.Adapter
{
    // target interface our client expects
    public interface IPaymentProcessor
    {
        void Pay(double amount);
    }

    // third party class with non-standard method
    public class PayPalGateway
    {
        public void SendPayment(double usdAmount)
        {
            Console.WriteLine($"[PayPal] Sent payment of ${usdAmount}");
        }
    }

    // adapter to translate standard call to paypal
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway _gateway;

        public PayPalAdapter(PayPalGateway gateway)
        {
            _gateway = gateway;
        }

        public void Pay(double amount)
        {
            _gateway.SendPayment(amount);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- adapter design pattern test ---");

            PayPalGateway legacyApi = new PayPalGateway();
            IPaymentProcessor processor = new PayPalAdapter(legacyApi);
            
            processor.Pay(120.50);
        }
    }
}