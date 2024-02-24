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
            string title = txtTitle.Text;
            string content = RtfService.GetRtfContentAsText(rtbNote);
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите текст.");
            }

            var newNote = new Note()
            {
                Title = title,
                Content = content,
            };

            _notesStore.AddNote(newNote);

            Close();
        }
    }
}
