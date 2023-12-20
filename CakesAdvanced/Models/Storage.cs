using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CakesAdvanced.Models
{
    internal class Storage
    {
        const string INGREDIENTS_PATH = "ingredients.json";
        private List<Ingredient> _allingredients = new List<Ingredient>();

        public void SaveIngredients()
        {
            var serializedIngredients = JsonConvert.SerializeObject(_allingredients);
            File.WriteAllText(INGREDIENTS_PATH, serializedIngredients);
        }
        public void LoadIngredients()
        {
            if (File.Exists(INGREDIENTS_PATH))
            {
                var serializedIngredients = File.ReadAllText(INGREDIENTS_PATH);
                _allingredients = JsonConvert.DeserializeObject<List<Ingredient>>(serializedIngredients);
                return;
            }
            else
            {
                throw new Exception("Такого файла не существует!");
            }
        }
        public Storage ()
        {
            LoadIngredients();
        }
        public Ingredient?  FindIngredientByName(string Name)
        {
            return _allingredients.Find(x => x.Name.ToLower() == Name.ToLower());
        }
        public Ingredient GetIngredientByName(string Name)
        {
            try
            {
                return _allingredients.First(x => x.Name.ToLower() == Name.ToLower());
            }
            catch
            {
                throw new Exception("Ингредиент не найден");
            }
        }
        public void AddIngredient(Ingredient ingredient)
        {
            var existingIngredient = FindIngredientByName(ingredient.Name);
            if (existingIngredient != null)
            {
                existingIngredient.Quantity += ingredient.Quantity;
            }
            else
            {
                _allingredients.Add(ingredient);
            }
            SaveIngredients();
        }
        public void AddIngredients(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                AddIngredient(ingredient);
            }
        }
        public void VerifyIngredientsAvailability(Dictionary<string, int> neededIngredients)
        {
            foreach (var ingredient in neededIngredients)
            {
                Ingredient? existingIngredient = FindIngredientByName(ingredient.Key);
                if (existingIngredient == null)
                {
                    throw new Exception("Ингредиент не найден.");
                }
                else if (existingIngredient.Quantity < ingredient.Value)
                {
                    throw new Exception("Недостаточное количество");
                }
            }

        }
        public List<Ingredient> TakeIngredients(Dictionary<string, int> neededIngredients)
        {
            VerifyIngredientsAvailability(neededIngredients);
            List<Ingredient> ingredientsToReturn = new List<Ingredient>();
            foreach (var i in neededIngredients)
            {
                string ingredientKey = i.Key;
                int ingredientValue = i.Value;
                Ingredient getIngredient = GetIngredientByName(ingredientKey);
                getIngredient.Quantity = getIngredient.Quantity - ingredientValue;
                Ingredient newIngredient = new Ingredient
                {
                    Name = getIngredient.Name,
                    Quantity = getIngredient.Quantity,
                    Cost = getIngredient.Cost,
                };
                ingredientsToReturn.Add(newIngredient);
            }
            SaveIngredients();
            return ingredientsToReturn;
        }
    }
}
