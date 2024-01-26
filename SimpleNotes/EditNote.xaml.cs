using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Documents;

namespace SimpleNotes
{
    public partial class EditNote : Window
    {
        private readonly NotesStore _notesStore;
        private readonly Note _noteToEdit;
        
        public EditNote(NotesStore notesStore, Note noteToEdit)
        {
            InitializeComponent();
            _notesStore = notesStore;
            _noteToEdit = noteToEdit;
            txtEdit.Text = noteToEdit.Text;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var editText = txtEdit.Text;
            _notesStore.EditNote(_noteToEdit, editText);
            Close();

            
        }
    }
}
