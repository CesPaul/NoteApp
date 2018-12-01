using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class AddAndEditNoteForm : Form
    {
        public AddAndEditNoteForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string name = TitleTextBox.Text;
            string content = ContentTextBox.Text;
            NoteCategory noteCategory = NoteCategory.Other;

            // Парсим с комбобокса выбранную пользователем категорию.
            // Если не спарсил - то поставит дефолтное значение NoteCategory.
            Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out noteCategory);
            Note note = new Note(name, content, noteCategory);

            Close();
        }
    }
}
