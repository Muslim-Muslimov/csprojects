using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SimpleNotes
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        const string PATH = "notes.json";
        public string ViewModel { get; set; }
        public Window1()
        {
            InitializeComponent();
        }
        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
        private void btnNewAdd_Click(object sender, RoutedEventArgs e)
        {
            string input = txtAdd.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст.");
            }
            Note newNote = new Note()
            {
                Text = input,
            };
            Note.Notes.Add(newNote);
            SaveNotes();
        }


        public void SaveNotes()
        {
            var serializedNotes = JsonConvert.SerializeObject(Note.Notes);
            File.WriteAllText(PATH, serializedNotes);
        }

    }
}
