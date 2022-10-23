using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerInstance gamingComputer = new GamingComputerBuilder()
                .AddCPU()
                .AddGPU()
                .AddRAM()
                .AddCooler()
                .GetComputer();
            
            ComputerInstance workComputer = new WorkComputerBuilder()
                .AddCPU()
                .AddGPU()
                .AddRAM()
                .AddCooler()
                .GetComputer();
            
            Console.WriteLine(gamingComputer);
            Console.WriteLine(workComputer);
        }
    }
}