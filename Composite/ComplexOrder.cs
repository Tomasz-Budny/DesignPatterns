using System.Collections.Generic;

namespace Composite
{
    public interface IValuable
    {
        int CalculatePrice();
    }
    
    public class ConcreteProduct : IValuable
    {
        private readonly string _name;
        private readonly int _price;

        public ConcreteProduct(int price, string name)
        {
            _name = name;
            this._price = price;
        }

        public int CalculatePrice()
        {
            return _price;
        }
    }
    
    public class Order : IValuable
    {
        private readonly List<IValuable> _products = new List<IValuable>();

        public void Add(IValuable product)
        {
            _products.Add(product);
        }
        
        public int CalculatePrice()
        {
            int total = 0;
            foreach (var product in _products)
            {
                total += product.CalculatePrice();
            }
            return total;
        }
    }
}