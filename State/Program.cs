using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.ChangeState(new MachineState(context));
            
            context.ProcessConnectionWithClient();
        }
    }
}