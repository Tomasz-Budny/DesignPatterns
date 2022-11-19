using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitFactory factory = new UnitFactory();
            
            Knight k1 = new Knight(factory
                    .GetFlyweight("red texture", "Tom"), 0, 0);
            Canon c1 = new Canon(factory
                .GetFlyweight("green texture", "Bart"), 10, 10);

            Villager v1 = new Villager(factory
                .GetFlyweight("red texture", "Tom"), 10, 10);
            
            k1.ShowResume();
            Console.WriteLine();
            c1.ShowResume();
            Console.WriteLine();
            v1.ShowResume();
            
            // po zmianie

            Console.WriteLine();
            c1.DealDamage(400);
            k1.Move(10, 50);
            Console.WriteLine();

            k1.ShowResume();
            Console.WriteLine();
            c1.ShowResume();
            Console.WriteLine();
            v1.ShowResume();
        }
    }
}