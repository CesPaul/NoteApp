using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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
            set
            {
                if (value == null)
                {
                    _currentProjectData = new ProjectData("ProjectData");
                }
                else
                {
                    _currentProjectData = value;
                }

            }
        }

        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));

            // Пытаемся загрузить данные из файла. Если нет - создаём новый файл.
            try
            {
                CurrentProjectData = ProjectDataManager.LoadFromFile("ProjectData");
            }
            // Создаём директорию храниения файла при её отсутствии.
            catch (DirectoryNotFoundException)
            {
                if (Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp") == false)
                {
                    Directory.CreateDirectory(
                        System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp");
                    File.Create(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                "\\NoteApp\\NoteApp.notes");

                    CurrentProjectData = new ProjectData("ProjectData");
                }
            }
            // Создаём пустой файл хранения данных проекта.
            catch (FileNotFoundException)
            {
                if (Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.notes") == false)
                {
                    File.Create(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.notes");
                }

                CurrentProjectData = new ProjectData("ProjectData");
            }

            // Подгрузка данных в ListBox.
            NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";

            // Чистим поля.
            ClearFields();

            // Временная фича для автодобавления тестовой заметки.
            // TODO: Удалить форму AddTestNote.cs и этот блок после разработки бизнес-логики.
            {
                AddTestNoteForm addTestNoteForm = new AddTestNoteForm();
                addTestNoteForm.AddNote();
                CurrentProjectData.Notes.Add(addTestNoteForm.CurrentNote);
                ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                UpdateNotesList();
            }
        }

        // Обновление листа заметок.
        private void UpdateNotesList()
        {
            // Перезагружаем проект
            CurrentProjectData = ProjectDataManager.LoadFromFile("ProjectData");

            // Обновляем данные коллекции
            NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";
        }

        // Очистка полей.
        private void ClearFields()
        {
            NoteNameLabel.Text = "";
            CategoryLabel.Text = "";
            CreatedDateTimePicker.ResetText();
            ModifiedDateTimePicker.ResetText();
            ContentTextBox.Text = "";
        }

        // События кнопок.
        #region Buttons

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddAndEditNoteForm addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.AddNote();

            if (addAndEditNoteForm.ShowDialog() == DialogResult.OK)
            {
                CurrentProjectData.Notes.Add(addAndEditNoteForm.CurrentNote);
                ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                UpdateNotesList();
            }
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedIndex != -1)
            {
                AddAndEditNoteForm addAndEditNoteForm = new AddAndEditNoteForm();
                addAndEditNoteForm.EditNote(CurrentProjectData.Notes[NoteId]);

                if (addAndEditNoteForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentProjectData.Notes[NoteId] = addAndEditNoteForm.CurrentNote;
                    ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                    UpdateNotesList();
                }
            }
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to remove note?", "NoteApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CurrentProjectData.Notes.RemoveAt(NoteId);
                    ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                    ClearFields();
                    UpdateNotesList();
                }
            }
        }

        #endregion

        // События кнопок меню.
        #region Menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndEditNoteForm addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.AddNote();

            if (addAndEditNoteForm.ShowDialog() == DialogResult.OK)
            {
                CurrentProjectData.Notes.Add(addAndEditNoteForm.CurrentNote);
                ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                UpdateNotesList();
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
                    ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                    UpdateNotesList();
                }
            }
        }

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to remove note?", "NoteApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CurrentProjectData.Notes.RemoveAt(NoteId);
                    ProjectDataManager.SaveToFile(CurrentProjectData, "ProjectData");
                    UpdateNotesList();
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
                CreatedDateTimePicker.Value = CurrentProjectData.Notes[NoteId].DateOfCreation;
                ModifiedDateTimePicker.Value = CurrentProjectData.Notes[NoteId].DateOfLastEdit;
            }
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
                    ProjectDataManager.SaveToFile(CurrentProjectData, "Project");
                }
            }

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
