using System;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows;


namespace SimpleNotes
{

    public partial class MainWindow : Window
    {
        private readonly NotesStore _notesStore = new NotesStore();


        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            _notesStore.LoadNotes();
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow windowAddNote = new AddNoteWindow();
            windowAddNote.ShowDialog();
            Note newNote = AddNoteWindow.Note;
            Notes.Add(newNote);
            _notesStore.AddNote(newNote);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var input = lstVyvod.SelectedItems.Cast<Note>().ToList();
            try
            {
                foreach (var note in input)
                {
                    Notes.Remove(note);
                    _notesStore.RemoveNote(note);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }



        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstVyvod.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Выберите элемент для редактирования");
            }
            Note existingNote = Notes[selectedIndex];
            string changeText = txtVvod.Text;
            _notesStore.EditNote(existingNote, changeText);
            existingNote.Text = changeText;

        }
    }
}
