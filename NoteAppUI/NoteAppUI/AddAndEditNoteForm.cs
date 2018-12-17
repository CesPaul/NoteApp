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

        // Редактируемая запись. Если форма открыта на добавление, то null.
        private readonly Note _editNote;

        private Note _currentNote;
        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }

        private NoteCategory _currentCategory;
        public NoteCategory CurrentCategory { get => _currentCategory; set => _currentCategory = value; }
        
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
            TitleTextBox.Text = "Noname";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CreatedDateTimePicker.Value = DateTime.Now;
            ModifiedDateTimePicker.Value = DateTime.Now;
        }

        // TODO: Доработать подгрузку категории редактируемой заметки.
        /// <summary>
        /// Метод редактирования заметки.
        /// </summary>
        /// <param name="currentNote"></param>
        public void EditNote(Note currentNote)
        {
            CurrentNote = currentNote;

            //Флаг на редактирование.
            IsEdit = true;

            //Заполнение данных
            TitleTextBox.Text = CurrentNote.Name;
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CreatedDateTimePicker.Value = CurrentNote.DateOfCreation;
            ModifiedDateTimePicker.Value = CurrentNote.DateOfLastEdit;
            ContentTextBox.Text = CurrentNote.Content;

        }
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            {
                /*if (_isEdit)
                {
                    if (_editNote == null)
                    {
                        throw new ArgumentException("Note is null in edit mode.");
                    }
                    _editNote.Name = TitleTextBox.Text;
                    _editNote.Content = ContentTextBox.Text;
                    // Парсим с комбобокса выбранную пользователем категорию.
                    // Если не спарсил - то поставит дефолтное значение NoteCategory.
                    _editNote.Category = noteCategory;
                }
                else
                {
                    // Парсим с комбобокса выбранную пользователем категорию.
                    // Если не спарсил - то поставит дефолтное значение NoteCategory.
                    //Enum.TryParse<NoteCategory>(CategoryComboBox.SelectedValue.ToString(), out NoteCategory.Other);*/
            }
            CurrentNote = new Note(TitleTextBox.Text, ContentTextBox.Text, CurrentCategory);
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
