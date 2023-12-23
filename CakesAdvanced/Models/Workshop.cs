using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Workshop
    {
 
        Dictionary<string, Dictionary<string, int>> _recipes = new Dictionary<string, Dictionary<string, int>>();

        public Dictionary<string, Dictionary<string, int>> GetAllRecipes() 
        {
            return _recipes; 
        }
        public Workshop()
        {
            Dictionary<string, int> Medovik = new Dictionary<string, int>()
           {
               {"Мука", 10 },
               {"Мёд", 4 },
               {"Сахар", 6 }
           };
            Dictionary<string, int> Napaleon = new Dictionary<string, int>()
            {
                {"Мука", 11},
                {"Сливочное масло", 7 },
                {"Водка", 2 }
            };
            _recipes.Add("Medovik", Medovik);
            _recipes.Add("Napaleon", Napaleon);
        }
    }
}
