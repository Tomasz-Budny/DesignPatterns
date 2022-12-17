using System;

namespace TemplateMethod
{
    public abstract class VacuumRobot
    {
        public void Vacuum()
        {
            Move();
            TurnLeft();
            TurnRight();
            TurnOnLight();
            SoundSignal();
            UseMop();
        }

        protected abstract void Move();
        protected abstract void TurnLeft();
        protected abstract void TurnRight();
        protected abstract void TurnOnLight();
        protected abstract void SoundSignal();
        protected abstract void UseMop();
    }
    
    public class RoombaVacuumRobot: VacuumRobot
    {
        protected override void Move()
        {
            Console.WriteLine("Moving forward");
        }

        protected override void TurnLeft()
        {
            Console.WriteLine("Turning left");
        }

        protected override void TurnRight()
        {
            Console.WriteLine("Turning Right");
        }

        protected override void TurnOnLight()
        {
            Console.WriteLine("Turning lights on");
        }

        protected override void SoundSignal()
        {
            Console.WriteLine("Beep beep");
        }

        protected override void UseMop()
        {
            Console.WriteLine("Using mop");
        }
    }

    public class ChineseVacuumRobot: VacuumRobot
    {
        protected override void Move()
        {
            Console.WriteLine("Move forward 1 meter");
        }

        protected override void TurnLeft()
        {
            Console.WriteLine("Turning left");
        }

        protected override void TurnRight()
        {
            Console.WriteLine("Turning Right");
        }

        protected override void TurnOnLight()
        {
            // dont have lights
        }

        protected override void SoundSignal()
        {
            Console.WriteLine("Beep beep");
        }

        protected override void UseMop()
        {
            Console.WriteLine("Using mop");
        }
    }
}