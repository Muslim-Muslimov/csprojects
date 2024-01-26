using System.Windows;

namespace SimpleNotes
{
    public partial class AddNoteWindow : Window
    {
        private readonly NotesStore _notesStore;
        public AddNoteWindow(NotesStore notesStore)
        {
            InitializeComponent();
            _notesStore = notesStore;
        }
        private void btnNewAdd_Click(object sender, RoutedEventArgs e) // создаем новую запись
        {
            string input = txtAdd.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст.");
            }
            
            var newNote = new Note();
            newNote.Text = input;

            _notesStore.AddNote(newNote);

            Close();
        }
    }
}
