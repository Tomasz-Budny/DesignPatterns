using System.Collections.Generic;

namespace Builder
{
    public interface IComputerBuilder
    {
        IComputerBuilder AddRAM();
        IComputerBuilder AddGPU();
        IComputerBuilder AddCooler();
        IComputerBuilder AddCPU();
        ComputerInstance GetComputer();
    }
    public abstract class ComputerBuilder : IComputerBuilder
    {
        protected ComputerInstance _computer = new ComputerInstance();

        protected ComputerBuilder()
        {
            this.Reset();
        }
        public ComputerInstance GetComputer()
        {
            var result = _computer;
            this.Reset();
            return result;
        }
        public void Reset()
        {
            _computer = new ComputerInstance();
        }
        public abstract IComputerBuilder AddCooler();
        public abstract IComputerBuilder AddCPU();
        public abstract IComputerBuilder AddGPU();
        public abstract IComputerBuilder AddRAM();
    }

    public class GamingComputerBuilder: ComputerBuilder
    {
        public override IComputerBuilder AddRAM()
        {
            _computer.Add("gaming Ram");
            return this;
        }

        public override IComputerBuilder AddCPU()
        {
            _computer.Add("gaming cpu");
            return this;
        }

        public override IComputerBuilder AddGPU()
        {
            _computer.Add("gaming gpu");
            return this;
        }

        public override IComputerBuilder AddCooler()
        {
            _computer.Add("gaming cooler");
            return this;
        }
    }
    
    public class WorkComputerBuilder: ComputerBuilder
    {
        public override IComputerBuilder AddRAM()
        {
            _computer.Add("work Ram");
            return this;
        }

        public override IComputerBuilder AddCPU()
        {
            _computer.Add("work cpu");
            return this;
        }

        public override IComputerBuilder AddGPU()
        {
            _computer.Add("work gpu");
            return this;
        }

        public override IComputerBuilder AddCooler()
        {
            _computer.Add("work cooler");
            return this;
        }
    }
    public class ComputerInstance
    {
        private List<object> _parts = new List<object>();

        public void Add(string el)
        {
            _parts.Add(el);
        }

        public override string ToString()
        {
            return "Computer parts: \n" + GetListOfElements();
        }

        public string GetListOfElements()
        {
            string result = "";
            foreach(var el in _parts)
            {
                result += el + "\n";
            }
            return result;
        }
    }
}