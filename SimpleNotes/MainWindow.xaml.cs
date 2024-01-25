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

            RefreshListViewNotes();
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow windowAddNote = new AddNoteWindow(_notesStore);
            windowAddNote.ShowDialog();

            RefreshListViewNotes();
        }

        private void RefreshListViewNotes()
        {
            Notes.Clear();
            foreach (var note in _notesStore.GetNotes())
            {
                Notes.Add(note);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var input = lstVyvod.SelectedItems.Cast<Note>().ToList();
            try
            {
                foreach (var note in input)
                {
                    _notesStore.RemoveNote(note);
                }
                RefreshListViewNotes();
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
            string newText = txtVvod.Text;
            _notesStore.EditNote(existingNote, newText);
            
            RefreshListViewNotes();
        }
    }
}
