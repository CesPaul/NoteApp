using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class AddAndEditNoteForm : Form
    {
        // Если true - форма открыта для редактирования записи.
        // Если false - форма открыта для добавления записи.
        private Boolean _isEdit;

        public bool IsEdit
        {
            get { return _isEdit; }
            set { _isEdit = value; }
        }

        private Note _currentNote;

        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }
        
        public NoteCategory CurrentCategory;

        public AddAndEditNoteForm()
        {
            InitializeComponent();

            // Устанавливаем всплывающие подсказки
            OkButtonToolTip.SetToolTip(OkButton, "Save changes to current note");
            CancelButtonToolTip.SetToolTip(CancelButton, "Exit without saving");
        }
        
        /// <summary>
        /// Метод создания заметки.
        /// </summary>
        public void AddNote()
        {
            IsEdit = false;
            TitleTextBox.Text = "Noname";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            DateTime dateTimeNow = DateTime.Now;
            CreatedDateTimeLabel.Text = dateTimeNow.ToString();
            SetModifiedDateTime(dateTimeNow, dateTimeNow);
        }
        
        /// <summary>
        /// Метод редактирования заметки.
        /// </summary>
        /// <param name="currentNote"></param>
        public void EditNote(Note currentNote)
        {
            IsEdit = true;
            CurrentNote = currentNote;

            CurrentNote.DateOfLastEdit = DateTime.Now;

            //Заполнение данных
            TitleTextBox.Text = CurrentNote.Name;
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CreatedDateTimeLabel.Text = CurrentNote.DateOfCreation.ToString();
            SetModifiedDateTime(currentNote.DateOfLastEdit, currentNote.DateOfCreation);
            ContentTextBox.Text = CurrentNote.Content;
        }
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            // Парсим с комбобокса выбранную пользователем категорию.
            // Если не спарсил - то поставит дефолтное значение NoteCategory.
            Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out CurrentCategory);
            if (IsEdit)
            {
                var CurrentCreationDateTime = CurrentNote.DateOfCreation;
                CurrentNote = new Note(TitleTextBox.Text, ContentTextBox.Text, CurrentCategory);
                CurrentNote.DateOfCreation = CurrentCreationDateTime;
            }
            else
            {
                CurrentNote = new Note(TitleTextBox.Text, ContentTextBox.Text, CurrentCategory);
            }
            
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

        /// <summary>
        /// Реализует скрытие даты редактирования у созданных заметок.
        /// </summary>
        /// <param name="dateOfLastEdit"></param>
        /// <param name="dateOfCreation"></param>
        private void SetModifiedDateTime(DateTime dateOfLastEdit, DateTime dateOfCreation)
        {
            if (dateOfCreation == dateOfLastEdit)
            {
                ModifiedDateTimeLabel.Visible = false;
                ModifiedLabel.Visible = false;
            }
            else
            {
                ModifiedDateTimeLabel.Visible = true;
                ModifiedLabel.Visible = true;
            }

            ModifiedDateTimeLabel.Text = dateOfLastEdit.ToString();
        }
    }
}
