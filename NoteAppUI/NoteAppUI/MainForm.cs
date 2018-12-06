using System;
using System.IO;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Хранит экземпляр текущего проекта.
        /// </summary>
        private ProjectData _currentProject;

        /// <summary>
        /// Хранит номер текущей заметки.
        /// </summary>
        private int _noteId;

        public int NoteId { get; set; }

        public ProjectData CurrentProjectData { get; set; }

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
                if (Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                     "\\NoteApp") == false)
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
            /*NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";*/

            // Чистим поля.
           //ClearFields();
        }

        private void UpdateNotesList()
        {
            // Перезагружаем проект
            CurrentProjectData = ProjectDataManager.LoadFromFile("ProjectData");

            // Обновляем данные коллекции
            NotesListBox.DataSource = null;
            NotesListBox.DataSource = CurrentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";
        }

        private void ClearFields()
        {
            NoteNameLabel.Text = "";
            CategoryLabel.Text = "";
            CreatedTextBox.Text = "";
            ModifiedTextBox.Text = "";
            ContentTextBox.Text = "";
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            Form addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.ShowDialog();
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            // Form addAndEditNoteForm = new AddAndEditNoteForm(_projectData.Notes[0]);
            // addAndEditNoteForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
