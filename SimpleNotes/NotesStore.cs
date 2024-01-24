using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;

namespace SimpleNotes
{
    internal class NotesStore
    {
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();




    }
}
