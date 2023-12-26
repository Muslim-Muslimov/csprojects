using ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Store
    {
        internal string Name { get; }

        private Kitchen _kitchen;
        private Storage _storage;
        public Store(string name) 
        {
            Name = name;
            _storage = new Storage();
        }

        public void ShowManagerOptions()
        {
            string[] modeDiscription = { "1.Добавить ингредиенты" };
            int? mode = InputService.GetOption(modeDiscription);
            if (mode == 1)
            {
                AddIngredients();
            }
            Open();
            Console.ReadKey();
            Console.Clear();
        }

        public void AddIngredients()
        {
            Console.WriteLine("Введите ингредиенты в формате 'Название:Цена:Количество'");
            string text = Console.ReadLine();
            string[] ingredientSeparately = text.Split(',');
            try 
            {
                foreach (string s in ingredientSeparately)
                {
                    string[] ingredientDetails = s.Split(':');

                    Ingredient ingredients = new Ingredient()
                    {
                        Name = ingredientDetails[0],
                        Cost = Convert.ToDecimal(ingredientDetails[1]),
                        Quantity = Convert.ToInt32(ingredientDetails[2])
                    };
                    _storage.AddIngredient(ingredients);
                }
            }
            catch (Exception)
            {
                _storage.LoadIngredients();
            }
        }
        public void ShowClientOptions()
        {
            string[] options = { "1. Показать список возможных тортов", "2.Заказать торт" };
            int? mode = InputService.GetOption(options);
            Console.Clear();
            switch (mode)
            {
                case 1:
                    ShowAvailableCakeOptions();
                    break;

                case 2:
                    TakeOrder();
                    break;
            }
            Open();
            Console.ReadKey();
            Console.Clear();
        }
        public Dictionary<string, Dictionary<string, int>> ShowAvailableCakeOptions()
        {
            Dictionary<string, Dictionary<string, int>> avaibleRecipes = _kitchen.GetAvailableRecipes();
            if (avaibleRecipes == null)
            {
                throw new Exception("Нет доступных рецепторв");
            }
            Console.WriteLine(string.Join(",", avaibleRecipes));
            return avaibleRecipes;
        }
        public Cake TakeOrder()
        {
            Console.WriteLine("Введите название торта: ");
            string text = Console.ReadLine();
            if (text == null)
            {
                throw new Exception("Вы не ввели название");
            }
            try
            {
             var newCake =  _kitchen.MakeCake(text);
                Console.WriteLine($"{newCake.Name} {newCake.Price}");
                return newCake;
            }
            catch (Exception) 
            { 
                throw new Exception("Не удалось забахать торт");
            }
        }
        public void Open()
        {
            string[] options = { "1 - Менеджер", "2 - Клиент" };
            int? mode = InputService.GetOption(options);
            switch (mode)
            {
                case 1:
                    ShowManagerOptions();
                    break;

                case 2: 
                    ShowClientOptions(); 
                    break;
            }
        }
    }
}
