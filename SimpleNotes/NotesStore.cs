using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace SimpleNotes
{
    public class NotesStore
    {
        private List<Note> _notes = new List<Note>();
        const string PATH = "notes.json";
        public NotesStore()
        {
            LoadNotes();
        }
        public void LoadNotes() // загрузка записей
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
        public void SaveNotes() // сохранение записей
        {
            var serializedNotes = JsonConvert.SerializeObject(_notes);
            File.WriteAllText(PATH, serializedNotes);
        }
        public void AddNote(Note note) // добавление
        {

            _notes.Add(note);
            SaveNotes();
        }
        public void RemoveNote(Note note) // удаление
        {
            _notes.Remove(note);
            SaveNotes();
        }
        public List<Note> GetNotes() // возвращаем лист записей
        {
            return _notes;
        }
        public void EditNote(Note existingNote, string newText) // редактируем запись
        {
            var note = _notes.FirstOrDefault(n => n.Text == existingNote.Text);
            if (note == null)
            {
                throw new Exception("Нет такого элемента");
            }
            note.Text = newText;

            SaveNotes();
        }


    }
}
