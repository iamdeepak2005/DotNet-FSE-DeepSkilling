using System;

namespace DesignPatterns.Command
{
    // command interface
    public interface ICommand
    {
        void Execute();
    }

    // receiver
    public class Light
    {
        public void TurnOn() => Console.WriteLine("Light turned ON.");
        public void TurnOff() => Console.WriteLine("Light turned OFF.");
    }

    // concrete commands
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;
        public LightOnCommand(Light light) { _light = light; }
        public void Execute() => _light.TurnOn();
    }

    // invoker
    public class RemoteControl
    {
        private ICommand _command;
        public void SetCommand(ICommand cmd) => _command = cmd;
        public void PressButton() => _command.Execute();
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- command design pattern test ---");

            Light roomLight = new Light();
            ICommand lightOn = new LightOnCommand(roomLight);

            RemoteControl remote = new RemoteControl();
            remote.SetCommand(lightOn);
            remote.PressButton();
        }
    }
}