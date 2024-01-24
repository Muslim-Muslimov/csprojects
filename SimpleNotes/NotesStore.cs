using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace SimpleNotes
{
    internal class NotesStore
    {
        private List<Note> _notes  = new List<Note>();
        const string PATH = "notes.json";
        public void LoadNotes()
        {
            if (!File.Exists(PATH))
            {
                return;
            }

            var serializedNotes = File.ReadAllText(PATH);

            var notesFromFile = JsonConvert.DeserializeObject<List<Note>>(serializedNotes);
            if (notesFromFile == null)
            {
                MessageBox.Show("Notes are null");
                return;
            }

            _notes.Clear();
            foreach (var note in notesFromFile)
            {
                _notes.Add(note);
            }
        }
        public void SaveNotes()
        {
            var serializedNotes = JsonConvert.SerializeObject(_notes);
            File.WriteAllText(PATH, serializedNotes);
        }
        public void AddNote(Note note)
        {
            
            _notes.Add(note);
            SaveNotes();
        }
        public void RemoveNote(Note note)
        {
            _notes.Remove(note);
            SaveNotes();
        }
        public List<Note> GetNotes()
        {
            return _notes;
        }
        public void EditNote(Note note)
        {
            // to do
            SaveNotes();
        }


    }
}
