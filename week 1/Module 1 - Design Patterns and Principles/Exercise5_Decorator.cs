using System;

namespace DesignPatterns.Decorator
{
    // component interface
    public interface INotifier
    {
        void Send(string msg);
    }

    // base component (always sends email)
    public class EmailNotifier : INotifier
    {
        public void Send(string msg) => Console.WriteLine($"Email sent: {msg}");
    }

    // base decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected readonly INotifier _notifier;

        protected NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string msg) => _notifier.Send(msg);
    }

    // sms decorator
    public class SMSDecorator : NotifierDecorator
    {
        public SMSDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string msg)
        {
            base.Send(msg);
            Console.WriteLine($"SMS sent: {msg}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- decorator design pattern test ---");

            INotifier notifier = new EmailNotifier();
            INotifier decorated = new SMSDecorator(notifier);

            decorated.Send("System alert: high memory use!");
        }
    }
}