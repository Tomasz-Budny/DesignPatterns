namespace Prototype
{
    public class Server
    {
        public string Name { get; set; }
        public CPU Processor { get; set; }

        public Server ShallowClone()
        {
            return (Server)MemberwiseClone();
        }

        public Server DeepClone()
        {
            Server clone = (Server)MemberwiseClone();
            clone.Processor = new CPU()
            {
                Name = clone.Processor.Name,
                Speed = clone.Processor.Speed
            };
            return clone;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nCPU: Name: {Processor.Name}, Speed: {Processor.Speed}]";
        }

    }

    public class CPU
    {
        public string Name { get; set; }
        public float Speed { get; set; }
    }
}