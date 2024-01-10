using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesLibrary.Models
{
    public class Kitchen
    {
        private Storage _storage;
        private Workshop _workshop;

        public Kitchen(Storage storage)
        {
            _storage = storage;
            _workshop = new Workshop();
        }

        public Dictionary<string, Dictionary<string, int>> GetAvailableRecipes()
        {
            Dictionary<string, Dictionary<string, int>> allRecipes = _workshop.GetAllRecipes();
            Dictionary<string, Dictionary<string, int>> availableRecipes = new Dictionary<string, Dictionary<string, int>>();

            foreach (var recipe in allRecipes)
            {
                try
                {
                    _storage.VerifyIngredientsAvailability(recipe.Value);
                    availableRecipes.Add(recipe.Key, recipe.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return availableRecipes;
        }
        public Cake MakeCake(string cakeName)
        {
            Dictionary<string, Dictionary<string, int>> availableRecipes = GetAvailableRecipes();
            var recipe = availableRecipes.FirstOrDefault(r => r.Key.ToLower() == cakeName.ToLower());
            if (recipe.Key == null)
            {
                throw new Exception("Нетю такого");
            }
            List<Ingredient> ingredients = _storage.TakeIngredients(recipe.Value);
            Cake newCake = new Cake(recipe.Key, ingredients);
            return newCake;
        }
    }
}
