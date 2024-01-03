using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Cake
    {
        internal string Name {  get; }
        internal decimal Price { get; }

        private List<Ingredient> _ingredients  = new List<Ingredient>();

        internal Cake(string name, List<Ingredient> ingredients)
        {
            Name = name;
            _ingredients = ingredients;
            Price = _ingredients.Sum(i => (i.Cost * 0.5m) * i.Quantity);

            //decimal price = 0;
            //foreach (var ingredient in _ingredients)
            //{
            //   price = price + (ingredient.Cost * ingredient.Quantity);
            //}
            //Price = price * 0.5m;
        }  
    }
}
