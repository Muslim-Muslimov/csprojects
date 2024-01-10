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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        private Storage _storage;
        private Kitchen _kitchen;

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
        }
    }
}
