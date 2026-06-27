using System;

namespace DesignPatterns.Builder
{
    // computer class that we will build
    public class Computer
    {
        public string CPU { get; }
        public string RAM { get; }
        public string Storage { get; }
        public string GPU { get; }

        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GPU = builder.GPU;
        }

        public void Display()
        {
            Console.WriteLine($"Specs: CPU={CPU}, RAM={RAM}, Storage={Storage}, GPU={GPU ?? "None"}");
        }

        // nested builder class
        public class Builder
        {
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }
            public string GPU { get; private set; }

            public Builder SetCPU(string cpu) { CPU = cpu; return this; }
            public Builder SetRAM(string ram) { RAM = ram; return this; }
            public Builder SetStorage(string storage) { Storage = storage; return this; }
            public Builder SetGPU(string gpu) { GPU = gpu; return this; }

            public Computer Build() => new Computer(this);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- builder design pattern test ---");

            // build gaming computer
            Computer gamingPc = new Computer.Builder()
                .SetCPU("Ryzen 9")
                .SetRAM("32GB")
                .SetStorage("2TB NVMe")
                .SetGPU("RTX 4080")
                .Build();

            gamingPc.Display();
        }
    }
}