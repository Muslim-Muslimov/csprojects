using CakesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakesWpf
{

    public partial class MainWindow : Window
    {

        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<string> Recipes { get; set; } = new ObservableCollection<string>();
        private Storage _storage = new Storage();
        private Kitchen _kitchen;
        private string _selectedCakeName;
        private List<Ingredient> _selectedIngredients;


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
            UpdateIngredientsView();
            UpdateRecipesView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = new Ingredient();
            ingredient.Name = txtName.Text;
            ingredient.Cost = Convert.ToDecimal(txtCost.Text);
            ingredient.Quantity = Convert.ToInt32(txtQuantity.Text);
            _storage.AddIngredient(ingredient);
            UpdateIngredientsView();
        }

        private void btnTakeOrder_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(_selectedCakeName))
            {
                MessageBox.Show("Вы не ввели название");
            }
            else if (!Recipes.Contains(_selectedCakeName))
            {
                MessageBox.Show("Такой мы не можем сделать, пожалуйста выберите из списка");
            }
            else
            {
                MessageBox.Show($"Заказ принят {_selectedCakeName}");
                try
                {
                    _kitchen.MakeCake(_selectedCakeName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UpdateRecipesView();
                _selectedCakeName = "";
            }
        }
        private void tabClient_GotFocus(object sender, RoutedEventArgs e)
        {
            //UpdateRecipesView();
        }
        private void UpdateRecipesView()
        {
            Recipes.Clear();
            var avaibleRecipes = _kitchen.GetAvailableRecipes().Keys;

            foreach (var recipe in avaibleRecipes)
            {
                Recipes.Add(recipe);
            }
        }
        private void UpdateIngredientsView()
        {
            Ingredients.Clear();
            var availableIngredients = _storage.GetAllIngredients();
            foreach (var ingredient in availableIngredients)
            {
                Ingredients.Add(ingredient);
            }
        }

        private void tabManager_GotFocus(object sender, RoutedEventArgs e)
        {
            //  UpdateIngredientsView();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            _selectedCakeName = e.AddedItems[0]!.ToString()!;


        }

        private void lstIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            _selectedIngredients = new List<Ingredient>();
            foreach (var item in e.AddedItems)
            {
                var ingredient = item as Ingredient;
                _selectedIngredients.Add(ingredient);
            }
        }
    }
}
