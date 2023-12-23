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
        }

    }
}
