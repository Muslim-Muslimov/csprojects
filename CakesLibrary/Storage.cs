﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLitePCL;

namespace CakesLibrary.Models
{
    public class Storage
    {
        const string INGREDIENTS_PATH = "ingredients.json";
        public List<Ingredient> _allingredients = new List<Ingredient>();

        public void SaveIngredients()
        {
            
        }

        public Storage()
        {
            var context = new MyDbContext();

        }
        public Ingredient? FindIngredientByName(string Name)
        {
            return _allingredients.Find(x => x.Name?.ToLower() == Name?.ToLower());
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
            SaveIngredients();
            return ingredientsToReturn;
        }
        public List<Ingredient> GetAllIngredients()
        {
            return _allingredients;
        }
    }
}
