using System;
using System.Threading;
using System.Threading.Tasks;

namespace State
{
    public abstract class State
    {
        protected Context _context;

        protected State(Context context)
        {
            _context = context;
        }
        
        public abstract void ProcessConnectionWithClient();

        public void SetContext(Context context)
        {
            _context = context;
        }

        protected void WaitSomeTime(int min, int max)
        {
            Thread.Sleep(new Random().Next(min, max));
            _context.IsClientSatisfied = new Random().Next(0, 5) == 4;
        }
    }

    public class EndedState : State
    {
        public EndedState(Context context) : base(context) {}
        public override void ProcessConnectionWithClient()
        {
            Console.WriteLine("ended state method");
            // do nothing
        }
    }

    public class MachineState : State
    {
        public MachineState(Context context) : base(context) {}
        
        public override async void ProcessConnectionWithClient()
        {
            Console.WriteLine("Machine State method");

            WaitSomeTime(1000, 3000);
            if (_context.IsClientSatisfied)
            {
                _context.ChangeState(new EndedState(_context));
            }
            else
            {
                _context.ChangeState(new QueueState(_context));
                _context.ProcessConnectionWithClient();
            }
        }

    }

    public class QueueState : State
    {
        public QueueState(Context context) : base(context) {}

        public override async void ProcessConnectionWithClient()
        {
            Console.WriteLine("queue state method");

            
            WaitSomeTime(1000, 3000);
            if (_context.IsClientSatisfied)
            {
                _context.ChangeState(new EndedState(_context));
            }
            else
            {
                _context.ChangeState(new FirstSupportLineState(_context));
                _context.ProcessConnectionWithClient();

            }
        }
    }

    public class FirstSupportLineState : State
    {
        public FirstSupportLineState(Context context) : base(context)
        {
        }

        public override async void ProcessConnectionWithClient()
        {
            Console.WriteLine("first line state method");
            
            WaitSomeTime(1000, 3000);
            if (_context.IsClientSatisfied)
            {
                _context.ChangeState(new EndedState(_context));
            }
            else
            {
                _context.ChangeState(new SecondSupportLineState(_context));
                _context.ProcessConnectionWithClient();

            }
        }
    }
    
    public class SecondSupportLineState : State
    {
        public SecondSupportLineState(Context context) : base(context)
        {
        }

        public override void ProcessConnectionWithClient()
        {
            Console.WriteLine("second line state method");
            
            WaitSomeTime(1000, 3000);

            _context.ChangeState(new EndedState(_context));
            _context.ProcessConnectionWithClient();

        }
    }

    public class Context
    {
        private State _state;
        public bool IsClientSatisfied { get; set; }
        
        public void ChangeState(State state)
        {
            _state = state;
            state.SetContext(this);
        }

        public void ProcessConnectionWithClient()
        {
            if(_state != null)
             _state.ProcessConnectionWithClient();
        }
    }
}