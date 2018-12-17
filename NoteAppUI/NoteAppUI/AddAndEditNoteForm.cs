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

        private Note _currentNote;
        private NoteCategory _currentCategory;

        public NoteCategory CurrentCategory { get => _currentCategory; set => _currentCategory = value; }

        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }

        public AddAndEditNoteForm()
        {
            InitializeComponent();
            // Устанавливаем всплывающие подсказки
            OkButtonToolTip.SetToolTip(OkButton, "Save changes to current note");
            CancelButtonToolTip.SetToolTip(CancelButton, "Exit without saving");
        }

        public void AddNote()
        {
            TitleTextBox.Text = "Note";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CreatedDateTimePicker.Value = DateTime.Now;
            ModifiedDateTimePicker.Value = DateTime.Now;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            /*if (_isEdit)
            {*/
                /*if (_editNote == null)
                {
                    throw new ArgumentException("Note is null in edit mode.");
                }
                _editNote.Name = TitleTextBox.Text;
                _editNote.Content = ContentTextBox.Text;
                NoteCategory noteCategory = NoteCategory.Other;
                // Парсим с комбобокса выбранную пользователем категорию.
                // Если не спарсил - то поставит дефолтное значение NoteCategory.
                Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out noteCategory);
                _editNote.Category = noteCategory;*/
            /*}
            else
            {*/
                //NoteCategory noteCategory = NoteCategory.Other;
                
                // Парсим с комбобокса выбранную пользователем категорию.
                // Если не спарсил - то поставит дефолтное значение NoteCategory.
                //Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out noteCategory);
                CurrentNote = new Note(TitleTextBox.Text, ContentTextBox.Text, NoteCategory.Other);
            /*}*/
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit without saving?", "NoteApp",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
