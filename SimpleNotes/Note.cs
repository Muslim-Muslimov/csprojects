using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes
{
    public class Note
    {
        public static ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        public string Text { get; set; }
    }
}
