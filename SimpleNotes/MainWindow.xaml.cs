using System;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows;


namespace SimpleNotes
{

    public partial class MainWindow : Window
    {
        private readonly NotesStore _notesStore = new NotesStore(); //поле только для чтения, что бы код каждый раз не создовал новый объект
        ///private readonly Note _noteToEdit = new Note();
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            RefreshListViewNotes();
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e) // создание новой записи
        {
            AddNoteWindow windowAddNote = new AddNoteWindow(_notesStore); // переход в новое окно
            windowAddNote.ShowDialog();

            RefreshListViewNotes();
        }

        private void RefreshListViewNotes() // обновление списка
        {
            Notes.Clear();
            foreach (var note in _notesStore.GetNotes())
            {
                Notes.Add(note);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) // удаление заметок
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

        private void btnChange_Click(object sender, RoutedEventArgs e) // редактирование
        {
            var notetoEdit = (Note)lstVyvod.SelectedItem;
            if (notetoEdit == null)
            {
                MessageBox.Show("Выберите элемент для редактирования");
            }
            EditNote editNote = new EditNote(_notesStore, notetoEdit);
            editNote.ShowDialog();
            
           // Note existingNote = Notes[selectedIndex];
           // string newText = txtVvod.Text;
           // _notesStore.EditNote(existingNote, newText);
            
            RefreshListViewNotes();
        }
    }
}
