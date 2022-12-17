using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var r1 = new RoombaVacuumRobot();
            r1.Vacuum();

            Console.WriteLine();
            
            var r2 = new ChineseVacuumRobot();
            r2.Vacuum();
        }
    }
}