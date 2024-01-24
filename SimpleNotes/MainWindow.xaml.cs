﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Newtonsoft.Json;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;

namespace SimpleNotes
{

    public partial class MainWindow : Window
    {
        const string PATH = "notes.json";

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            LoadNotes();
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow windowAddNote = new AddNoteWindow();
            windowAddNote.ShowDialog();
            Note newNote = AddNoteWindow.Note;
            Notes.Add(newNote);
            SaveNotes();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var input = lstVyvod.SelectedItems.Cast<Note>().ToList();
            try
            {
                foreach (var note in input)
                {
                    Notes.Remove(note);
                }
                SaveNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        public void SaveNotes()
        {
            var serializedNotes = JsonConvert.SerializeObject(Notes);
            File.WriteAllText(PATH, serializedNotes);
        }
        public void LoadNotes()
        {
            if (!File.Exists(PATH))
            {
                return;
            }

            var serializedNotes = File.ReadAllText(PATH);

            var notesFromFile = JsonConvert.DeserializeObject<ObservableCollection<Note>>(serializedNotes);
            if (notesFromFile == null)
            {
                MessageBox.Show("Notes are null");
                return;
            }

            Notes.Clear();
            foreach (var note in notesFromFile)
            {
                Notes.Add(note);
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstVyvod.SelectedIndex;
            string changeText = txtVvod.Text;
            Note changeNote = new Note()
            {
                Text = changeText,
            };
            try
            {
                Notes.RemoveAt(selectedIndex);
                Notes.Add(changeNote);
                SaveNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите элемент для редактирования.");
            }
        }
        public void AddNote()
        {
            string input = txtVvod.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст.");
            }
            Note newNote = new Note()
            {
                Text = input,
            };
            Notes.Add(newNote);
            SaveNotes();
        }
    }
}
