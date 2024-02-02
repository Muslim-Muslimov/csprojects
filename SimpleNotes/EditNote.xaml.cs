using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            // rtbEdit = noteToEdit.Text;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            OpenFile();
        }
        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }
        //d:DataContext="{d:DesignInstance Type=local:MainWindow, IsDesignTimeCreatable=True}"
    }
}

