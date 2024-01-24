using System.Windows;

namespace SimpleNotes
{
    public partial class AddNoteWindow : Window
    {
        public static Note Note { get; } = new Note();
        public AddNoteWindow()
        {
            InitializeComponent();
        }
        private void btnNewAdd_Click(object sender, RoutedEventArgs e)
        {
            string input = txtAdd.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст.");
            }

            Note.Text = input;
            Close();
        }
    }
}
