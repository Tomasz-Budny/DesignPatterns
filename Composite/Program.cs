using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            Order subOrder = new Order();
            subOrder.Add(new ConcreteProduct(100, "product A"));
            subOrder.Add(new ConcreteProduct(100, "product B"));
            Order subSubOrder = new Order();
            subSubOrder.Add(new ConcreteProduct(50, "product C"));
            subOrder.Add(subSubOrder);
            
            order.Add(subOrder);
            order.Add(new ConcreteProduct(50, "product D"));

            Console.WriteLine(order.CalculatePrice());
        }
    }
}