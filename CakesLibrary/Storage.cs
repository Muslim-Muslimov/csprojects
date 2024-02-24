namespace CakesLibrary.Models
{
    public class Storage
    {
        private MyDbContext _context;

        public Storage()
        {
            _context = new MyDbContext();
            _context.Database.EnsureCreated();
        }
        public Ingredient? FindIngredientByName(string Name)
        {
            var dbIngredient = _context.Ingredients.FirstOrDefault(x => x.Name == Name);
            return dbIngredient;
        }
        public Ingredient GetIngredientByName(string Name)
        {
            try
            {
                return _context.Ingredients.First(x => x.Name.ToLower() == Name.ToLower());
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
                _context.Ingredients.Add(ingredient);
            }

            _context.SaveChanges();
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
                string ingredientName = i.Key;
                int ingredientQuanity = i.Value;
                Ingredient getIngredient = GetIngredientByName(ingredientName);
                getIngredient.Quantity = getIngredient.Quantity - ingredientQuanity;
                Ingredient newIngredient = new Ingredient
                {
                    Name = getIngredient.Name,
                    Cost = getIngredient.Cost,
                    Quantity = ingredientQuanity,
                };
                ingredientsToReturn.Add(newIngredient);

            }

            _context.SaveChanges();
            return ingredientsToReturn;
        }
        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }
    }
}
