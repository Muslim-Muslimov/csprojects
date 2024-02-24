using System;
using System.Windows;


namespace SimpleNotes
{
    public partial class EditNote : Window
    {
        private readonly NotesStore _notesStore;
        private string _noteId;
        public EditNote(NotesStore notesStore, Note note)
        { 
            InitializeComponent();

            _notesStore = notesStore;
            _noteId = note.Id;

            txtTitle.Text = note.Title;
            RtfService.LoadRtfFromText(rtbNote, note.Content);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var title = txtTitle.Text;
            var content = RtfService.GetRtfContentAsText(rtbNote);

            _notesStore.EditNote(_noteId, title, content);
            Close();
        }
    }
}

