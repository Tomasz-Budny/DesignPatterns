using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server1 = new Server()
            {
                Name = "Server #1",
                Processor = new CPU()
                {
                    Name = "CPU #1",
                    Speed = 21
                }
            };

            var server2 = server1.ShallowClone();
            var server3 = server1.DeepClone();

            Console.WriteLine("before modifying server1:");
            Console.WriteLine("Server 1: " + server1);
            Console.WriteLine("Server 2: " + server2);
            Console.WriteLine("Server 3: " + server3);

            server1.Name = "different Name";
            server1.Processor.Name = "different processor";
            
            Console.WriteLine("\nafter modifying server1:");
            Console.WriteLine("Server 1: " + server1);
            Console.WriteLine("Server 2: " + server2);
            Console.WriteLine("Server 3: " + server3);
        }
    }
}