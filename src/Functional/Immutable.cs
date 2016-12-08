using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Functional
{
    public class Immutable
    {
        public IEnumerable<string> Example()
        {
            var fruitBasket = ImmutableList.Create<string>();
            
            fruitBasket = fruitBasket.Add("Apple");
            fruitBasket = fruitBasket.Add("Banana");
            fruitBasket = fruitBasket.Add("Celery");

            return fruitBasket.Where(f => f.StartsWith("A"));
        } 
    }
}