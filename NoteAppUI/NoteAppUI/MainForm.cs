using System;
using System.IO;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Хранит номер текущей заметки.
        /// </summary>
        private int _noteId;
        public int NoteId { get; set; }
        /// <summary>
        /// Хранит экземпляр текущего проекта.
        /// </summary>
        private ProjectData _currentProjectData;
        
        /// <summary>
        /// Хранит текущий проект.
        /// </summary>
        public ProjectData CurrentProjectData
        {
            get { return _currentProjectData; }
            set { _currentProjectData = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            CategoryComboBox.Items.Add("All");

            foreach (NoteCategory element in Enum.GetValues(typeof(NoteCategory)))
            {
                CategoryComboBox.Items.Add(element);
            }

            CategoryComboBox.SelectedIndex = 0;

            // Задаем клавишу быстрого доступа для удаления
            removeNoteToolStripMenuItem.ShortcutKeys = Keys.Delete;

            // Пытаемся загрузить данные из файла. Если нет - создаём новый файл.

            CurrentProjectData = ProjectDataManager.LoadFromFile();

            // Подгрузка данных в ListBox.
            NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";

            // Чистим поля.
            ClearFields();
        }

        // Обновление листа заметок.
        private void UpdateNotesList()
        {
            // Сохраняемся всякий раз, когда обновляем данные
            ProjectDataManager.SaveToFile(CurrentProjectData);

            // Перезагружаем проект
            CurrentProjectData = ProjectDataManager.LoadFromFile();

            // Обновляем данные коллекции
            NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";
        }

        /*private void UpdateNotesList(NoteCategory category)
        {
            // Сохраняемся всякий раз, когда обновляем данные
            ProjectDataManager.SaveToFile(CurrentProjectData);

            // Перезагружаем проект
            CurrentProjectData = ProjectDataManager.LoadFromFile();

            // Если нет заметок - ничего не делаем
            try
            {
                CurrentProjectData.SortNotesCollection();
            }
            catch (InvalidOperationException)
            {

            }

            // Обновляем данные коллекции
            NotesListBox.DataSource = null;

            // Если пришёл пустой список - ничего не делаем
            try
            {
                FilteredList = CurrentProjectData.SortNotesCollection(category);
                NotesListBox.DataSource = FilteredList;
            }
            catch (InvalidOperationException)
            {
            }

            NotesListBox.DisplayMember = "Name";

            //// Снимаем выделение
            //if (NotesListBox.Items.Count != 0)
            //{
            //    NotesListBox.SelectedIndex = -1;
            //}
        }*/

        // Очистка полей.
        private void ClearFields()
        {
            NoteNameLabel.Text = "";
            CategoryLabel.Text = "";
            CreatedDateTimeLabel.Text = "";
            ModifiedDateTimeLabel.Text = "";
            ContentTextBox.Text = "";
        }

        // События кнопок.
        #region Buttons

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            addNoteToolStripMenuItem_Click(sender, e);
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            editNoteToolStripMenuItem_Click(sender, e);
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            removeNoteToolStripMenuItem_Click(sender, e);
        }

        #endregion

        // События кнопок меню.
        #region Menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Для сохранения список заметок должен быть не пустым
            if (CurrentProjectData.Notes.Count != 0)
            {
                ProjectDataManager.SaveToFile(CurrentProjectData);
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Можно добавить только до 200 заметок
            if (CurrentProjectData.Notes.Count < 200)
            {
                AddAndEditNoteForm addEditNoteForm = new AddAndEditNoteForm();
                addEditNoteForm.AddNote();

                if (addEditNoteForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentProjectData.Notes.Add(addEditNoteForm.CurrentNote);
                    UpdateNotesList();
                }
            }
        }

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedIndex != -1)
            {
                AddAndEditNoteForm addAndEditNoteForm = new AddAndEditNoteForm();
                addAndEditNoteForm.EditNote(CurrentProjectData.Notes[NoteId]);

                if (addAndEditNoteForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentProjectData.Notes[NoteId] = addAndEditNoteForm.CurrentNote;
                    UpdateNotesList();
                }
            }
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Должна быть выбрана заметка.
            if (NotesListBox.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to remove note?", "NoteApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CurrentProjectData.Notes.RemoveAt(NoteId);
                    UpdateNotesList();

                    this.DialogResult = DialogResult.Cancel;
                }

                if (result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutForm();

            aboutForm.ShowDialog();
        }

        #endregion

        // Событие при смене выбора заметки.
        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NoteId = NotesListBox.SelectedIndex;

            if (NoteId != -1)
            {
                NoteNameLabel.Text = CurrentProjectData.Notes[NoteId].Name;
                ContentTextBox.Text = CurrentProjectData.Notes[NoteId].Content;
                CategoryLabel.Text = CurrentProjectData.Notes[NoteId].Category.ToString();
                CreatedDateTimeLabel.Text = CurrentProjectData.Notes[NoteId].DateOfCreation.ToString();
                SetModifiedDateTime();
            }
        }

        private void SetModifiedDateTime()
        {
            DateTime dateOfLastEdit = CurrentProjectData.Notes[NoteId].DateOfLastEdit;
            DateTime dateOfCreation = CurrentProjectData.Notes[NoteId].DateOfCreation;
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

        // Обработчик при закрытии окна программы.
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "NoteApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Для сохранения список заметок должен быть не пустым
                if (CurrentProjectData.Notes.Count != 0)
                {
                    if (NotesListBox.SelectedIndex != -1)
                    {
                        CurrentProjectData.CurrentNote = CurrentProjectData.Notes[NoteId];
                    }

                    if (NotesListBox.SelectedIndex == -1)
                    {
                        CurrentProjectData.CurrentNote = null;
                    }

                    ProjectDataManager.SaveToFile(CurrentProjectData);
                }
            }

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
