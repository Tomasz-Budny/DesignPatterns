using System.Collections.Generic;
using System.Linq;

namespace Flyweight
{
    public class UnitFactory
    {
        private readonly Dictionary<string, Unit> _cache = new Dictionary<string, Unit>();

        public Unit GetFlyweight(object texture, string player)
        {
            string key = $"{texture.GetHashCode()}_{player}";
            
            if (_cache.FirstOrDefault(el => el.Key == key).Key is null)
            {
                _cache.Add(key, new Unit(texture, player));
            }

            return _cache[key];
        }
    }
}