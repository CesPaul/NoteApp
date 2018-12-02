using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class AddAndEditNoteForm : Form
    {
        // Если true - форма открыта для редактирования записи.
        // Если false - форма открыта для добавления записи.
        private readonly Boolean _isEdit;
        // Редактируемая запись. Если форма открыта на добавление, то null.
        private readonly Note _editNote;

        public AddAndEditNoteForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            _isEdit = false;
        }

        public AddAndEditNoteForm(Note editNote) : this()
        {
            TitleTextBox.Text = editNote.Name;
            ContentTextBox.Text = editNote.Content;
            CategoryComboBox.SelectedIndex = (int) editNote.Category;
            _isEdit = true;
            _editNote = editNote;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                if (_editNote == null)
                {
                    throw new ArgumentException("Note is null in edit mode.");
                }
                _editNote.Name = TitleTextBox.Text;
                _editNote.Content = ContentTextBox.Text;
                NoteCategory noteCategory = NoteCategory.Other;
                // Парсим с комбобокса выбранную пользователем категорию.
                // Если не спарсил - то поставит дефолтное значение NoteCategory.
                Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out noteCategory);
                _editNote.Category = noteCategory;
            } else
            {
                string name = TitleTextBox.Text;
                string content = ContentTextBox.Text;
                NoteCategory noteCategory = NoteCategory.Other;

                // Парсим с комбобокса выбранную пользователем категорию.
                // Если не спарсил - то поставит дефолтное значение NoteCategory.
                Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out noteCategory);
                Note note = new Note(name, content, noteCategory);
            }
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
