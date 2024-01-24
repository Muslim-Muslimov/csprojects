using System;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows;


namespace SimpleNotes
{

    public partial class MainWindow : Window
    {
        

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            //LoadNotes();
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow windowAddNote = new AddNoteWindow();
            windowAddNote.ShowDialog();
            Note newNote = AddNoteWindow.Note;
            Notes.Add(newNote);
            //SaveNotes();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var input = lstVyvod.SelectedItems.Cast<Note>().ToList();
            try
            {
                foreach (var note in input)
                {
                    Notes.Remove(note);
                }
                //SaveNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }



        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstVyvod.SelectedIndex;
            string changeText = txtVvod.Text;
            Note changeNote = new Note()
            {
                Text = changeText,
            };
            try
            {
               // to do
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите элемент для редактирования.");
            }
        }
        public void AddNote()
        {
            string input = txtVvod.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст.");
            }
            Note newNote = new Note()
            {
                Text = input,
            };
            // to do
        }
    }
}
