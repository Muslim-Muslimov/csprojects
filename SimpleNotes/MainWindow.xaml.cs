using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Newtonsoft.Json;
using System.Windows.Shapes;


namespace SimpleNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string PATH = "notes.json";

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            GetAllNotes();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string input = txtVvod.Text;
            Note newNote = new Note()
            {
                Text = input,
            };
            Notes.Add(newNote);
            SaveNotes();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int input = lstVyvod.SelectedIndex;
            Notes.RemoveAt(input);
            //lstVyvod.Items.Refresh();
            SaveNotes();
        }
        public void SaveNotes()
        {
            var serializedNotes = JsonConvert.SerializeObject(Notes);
            File.WriteAllText(PATH, serializedNotes);
        }
        public void LoadNotes()
        {
            if (!File.Exists(PATH))
            {
                MessageBox.Show("Нет заметок");
                return;
            }

            var serializedNotes = File.ReadAllText(PATH);

            var notesFromFile = JsonConvert.DeserializeObject<ObservableCollection<Note>>(serializedNotes);
            if (notesFromFile == null)
            {
                MessageBox.Show("Notes are null");
                return;
            }

            Notes.Clear();
            foreach (var note in notesFromFile)
            {
                Notes.Add(note);
            }
        }

        public ObservableCollection<Note> GetAllNotes()
        {
            LoadNotes();

            return Notes;
        }
    }
}
