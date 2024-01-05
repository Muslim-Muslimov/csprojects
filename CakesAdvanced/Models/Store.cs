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
            _kitchen = new Kitchen(_storage);
        }

        public void ShowManagerOptions()
        {
            Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Добавить ингредиенты" },
                { '2', "Показать список ингредиентов в наличии" }
            };
            char selectedOption = InputService.GetOption("Выберите дествие", options);
            switch (selectedOption)
            {
                case '1':
                    AddIngredients();
                    Console.ReadKey();
                    Console.Clear();
                    Open();
                    break;
                case '2':
                    ShowIngredients();
                    Console.ReadKey();
                    Console.Clear();
                    Open();
                    break;
                default:
                    Open();
                    return;
            }
        }

        public void AddIngredients()
        {
            Console.WriteLine("Введите ингредиенты в формате 'Название:Цена:Количество'");
            string text = Console.ReadLine();
            if (String.IsNullOrEmpty(text))
            {
                Console.WriteLine("Вы ничего не ввели");
                Console.ReadKey();
                Open();
            }
            string[] ingredientSeparately = text.Split(',');
            try
            {
                foreach (string s in ingredientSeparately)
                {
                    string[] ingredientDetails = s.Split(':');
                    if (ingredientDetails.Length != 3)
                    {
                        Console.WriteLine($"Введите в соответствии с примером {ingredientDetails} ");
                        continue;
                    }

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
            Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Показать список возможных тортов" },
                { '2', "Заказать торт" }
            };
            char selectedOption = InputService.GetOption("Выберите дествие", options);
            switch (selectedOption)
            {
                case '1':
                    ShowAvailableCakeOptions();
                    Console.ReadKey();
                    Console.Clear();
                    Open();
                    break;
                case '2':
                    TakeOrder();
                    Console.ReadKey();
                    Console.Clear();
                    Open();
                    break;
                default:
                    Open();
                    return;
            }

        }
        public Dictionary<string, Dictionary<string, int>> ShowAvailableCakeOptions()
        {
            Dictionary<string, Dictionary<string, int>> avaibleRecipes = _kitchen.GetAvailableRecipes();
            if (avaibleRecipes.Keys.Count == 0)
            {
                Console.WriteLine("Нет доступных рецептов");
                Console.ReadKey();
                Console.Clear();
                Open();
            }
            Console.WriteLine(string.Join(",", avaibleRecipes.Keys));
            return avaibleRecipes;

        }
        public Cake TakeOrder()
        {
            Console.WriteLine("Введите название торта: ");
            string text = Console.ReadLine();
            if (String.IsNullOrEmpty(text))
            {
                Console.WriteLine("Вы не ввели название");
            }
            var newCake = _kitchen.MakeCake(text);
            Console.WriteLine($"{newCake.Name} {newCake.Price}");
            return newCake;
        }

            public void Open()
        {
            try
            {
                Console.WriteLine("Добро пожаловать!");
                Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Менеджер" },
                { '2', "Клиент" }
            };
                char selectedOption = InputService.GetOption("Выберите дествие", options);
                switch (selectedOption)
                {
                    case '1':
                        ShowManagerOptions();
                        break;

                    case '2':
                        ShowClientOptions();
                        break;
                    default:
                        Console.Clear();
                        Open();
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                Console.Clear() ;
                Open();
            }
        }
        public void ShowIngredients()
        {
            var ingredients = _storage.GetAllIngredients();
            Console.WriteLine("Ингридиенты на складе");
            Console.WriteLine("Название | Цена | Количество");
            foreach (var ingredient in ingredients)
            {
                Console.Write(ingredient.Name.PadRight(9));
                Console.Write("| ");
                Console.Write(ingredient.Cost.ToString().PadRight(5));
                Console.Write("|  ");
                Console.WriteLine(ingredient.Quantity);
            }
            Console.ReadKey();
            Console.Clear();
            Open();
        }
    }
}
