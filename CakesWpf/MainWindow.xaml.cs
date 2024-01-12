using CakesLibrary.Models;
using System;
using System.Collections.Generic;
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

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public Dictionary<string, Dictionary<string, int>> Recipes { get; set; } = new Dictionary<string, Dictionary<string, int>>();
        public List<Ingredient> AvaibleRecipes { get; set; } = new List<Ingredient>();
        private Storage _storage;
        private Kitchen _kitchen;
        private Ingredient _ingredient;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Ingredient ingredient;
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
            var availableIngredients = _storage.GetAllIngredients();
            Ingredients.AddRange(availableIngredients);
            Storage storage = new Storage(); Kitchen kitchen = new Kitchen(storage);
            Recipes = _kitchen.GetAvailableRecipes();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ingredient = new Ingredient();
            _ingredient.Name = txtName.Text;
            _ingredient.Cost = Convert.ToDecimal(txtCost.Text);
            _ingredient.Quantity = Convert.ToInt32(txtQuantity.Text);
            _storage.AddIngredient(_ingredient);
            _storage.GetAllIngredients();
            Ingredients = _storage.GetAllIngredients();
            lstIngredients.ItemsSource = Ingredients;
        }

        private void btnTakeOrder_Click(object sender, RoutedEventArgs e)
        {
            string cakeName = txtName.Text;
             var avaibleRecipes = _kitchen.GetAvailableRecipes();
            if (cakeName != avaibleRecipes.Keys.First())
            {
                MessageBox.Show("Такой мы не можем сделать, пожалуйста выберите из списка");
            }
            else if (string.IsNullOrEmpty(cakeName))
            {
                MessageBox.Show("Вы не ввели название");
            }
            else
            {
                MessageBox.Show("Заказ принят");
                _kitchen.MakeCake(cakeName);
                _kitchen.GetAvailableRecipes();
            }
        }
    }
}
