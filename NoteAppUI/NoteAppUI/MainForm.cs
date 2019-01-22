using System;
using System.Windows.Forms;
using System.Collections.Generic;
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

        /// <summary>
        /// Хранит список отфильтрованный по категории
        /// </summary>
        public List<Note> FilteredList { get; set; }

        public MainForm()
        {
            InitializeComponent();
            // Заполнение комбобокса с категориями.
            FillCategoryItems();
            // Задаем клавишу быстрого доступа для удаления.
            removeNoteToolStripMenuItem.ShortcutKeys = Keys.Delete;

            // Пытаемся загрузить данные из файла. Если нет - создаём новый файл.
            _currentProjectData = ProjectDataManager.LoadFromFile();

            UpdateNotesList();

            // Снятие выделения заметки и отображение всех заметок.
            NotesListBox.SelectedIndex = -1;
            CategoryComboBox.SelectedIndex = 0;

            // Защита кнопок от нажатия при невыбранной заметке.
            EditNoteButton.Enabled = false;
            RemoveNoteButton.Enabled = false;
        }

        // Обновление листа заметок.
        private void UpdateNotesList()
        {
            // Сохраняемся всякий раз, когда обновляем данные.
            ProjectDataManager.SaveToFile(_currentProjectData);

            // Перезагружаем проект.
            _currentProjectData = ProjectDataManager.LoadFromFile();

            _currentProjectData.Notes = _currentProjectData.OrderListByEditDate();

            // Обновляем данные коллекции.
            NotesListBox.DataSource = null;
            NotesListBox.DataSource = _currentProjectData.Notes;
            NotesListBox.DisplayMember = "Name";

            if (CategoryComboBox.SelectedIndex == 0)
            {
                NotesListBox.DataSource = _currentProjectData.OrderListByEditDate();
            }
            else if (CategoryComboBox.SelectedIndex >= 1)
            {
                NotesListBox.DataSource = _currentProjectData.OrderListByEditDate((NoteCategory)CategoryComboBox.SelectedIndex - 1);
            }

            NoteId = NotesListBox.SelectedIndex;

            // Обновление счётчика заметок.
            CountNotesLabel.Text = NotesListBox.Items.Count.ToString();
        }

        /// <summary>
        /// Заполняет категории заметки
        /// </summary>
        public void FillCategoryItems()
        {
            CategoryComboBox.Items.Add("All");
            CategoryComboBox.Items.Add(NoteCategory.Other.ToString());
            CategoryComboBox.Items.Add(NoteCategory.Documents.ToString());
            CategoryComboBox.Items.Add(NoteCategory.Finance.ToString());
            CategoryComboBox.Items.Add("Health and Sport");
            CategoryComboBox.Items.Add(NoteCategory.Home.ToString());
            CategoryComboBox.Items.Add(NoteCategory.People.ToString());
            CategoryComboBox.Items.Add(NoteCategory.Work.ToString());
        }

        // Очистка полей.
        private void ClearFields()
        {
            NoteNameLabel.Text = "";
            CategoryLabel.Text = "";
            CreatedDateTimeLabel.Text = "";
            ModifiedDateTimeLabel.Text = "";
            ContentTextBox.Text = "";
        }

        public void SetAllFieldsOfCurrentNote()
        {
            if (FilteredList == null)
            {
                // Меняем название заметки
                NoteNameLabel.Text = CurrentProjectData.Notes[NoteId].Name;

                // Особый случай с категориями
                if (CurrentProjectData.Notes[NoteId].Category == NoteCategory.HealthAndSport)
                {
                    CategoryLabel.Text = "Health and Sport";
                }
                else
                {
                    CategoryLabel.Text = CurrentProjectData.Notes[NoteId].Category.ToString();
                }

                // Меняем все остальные поля
                /*CreatedDateTimeLabel.Text = CurrentProjectData.Notes[NoteId].DateOfCreation.ToString();
                ModifiedDateTimeLabel.Text = CurrentProjectData.Notes[NoteId].DateOfLastEdit.ToString();*/
                SetModifiedDateTime();
                ContentTextBox.Text = CurrentProjectData.Notes[NoteId].Content;
            }
            else
            {
                // Меняем название заметки
                NoteNameLabel.Text = FilteredList[NoteId].Name;

                // Особый случай с категориями
                if (FilteredList[NoteId].Category == NoteCategory.HealthAndSport)
                {
                    CategoryLabel.Text = "Health and Sport";
                }
                else
                {
                    CategoryLabel.Text = FilteredList[NoteId].Category.ToString();
                }

                // Меняем все остальные поля
                CreatedDateTimeLabel.Text = FilteredList[NoteId].DateOfCreation.ToString();
                ModifiedDateTimeLabel.Text = FilteredList[NoteId].DateOfLastEdit.ToString();
                ContentTextBox.Text = FilteredList[NoteId].Content;
            }
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
                AddAndEditNoteForm addAndEditNoteForm = new AddAndEditNoteForm();
                addAndEditNoteForm.AddNote();

                if (addAndEditNoteForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentProjectData.Notes.Add(addAndEditNoteForm.CurrentNote);
                    UpdateNotesList();

                    // Выбор только что созданной заметки.
                    NotesListBox.SelectedIndex = 0;
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
                // При выборе заметки кнопки становятся доступны.
                EditNoteButton.Enabled = true;
                RemoveNoteButton.Enabled = true;

                DialogResult result = MessageBox.Show("Do you want to remove note?", "NoteApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CurrentProjectData.Notes.RemoveAt(NoteId);
                    ClearFields();
                    UpdateNotesList();
                    NotesListBox.SelectedIndex = 0;
                    
                    DialogResult = DialogResult.Cancel;
                }

                if (result == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }

            // Блокировка кнопок после удаления заметки если нет выбранной заметки.
            if (NotesListBox.SelectedIndex == -1)
            {
                ClearFields();

                EditNoteButton.Enabled = false;
                RemoveNoteButton.Enabled = false;
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
            if (CategoryComboBox.SelectedIndex >= 0)
            {
                NoteId = NotesListBox.SelectedIndex;
                if (NoteId != -1)
                {
                    // При выборе заметки кнопки доступны.
                    EditNoteButton.Enabled = true;
                    RemoveNoteButton.Enabled = true;

                    NoteNameLabel.Text = CurrentProjectData.Notes[NoteId].Name;
                    ContentTextBox.Text = CurrentProjectData.Notes[NoteId].Content;
                    if (CurrentProjectData.Notes[NoteId].Category == NoteCategory.HealthAndSport)
                    {
                        CategoryLabel.Text = "Health and Sport";
                    }
                    else
                    {
                        CategoryLabel.Text = CurrentProjectData.Notes[NoteId].Category.ToString();
                    }
                    CreatedDateTimeLabel.Text = CurrentProjectData.Notes[NoteId].DateOfCreation.ToString();
                    SetModifiedDateTime();
                }
                else
                {
                    ClearFields();
                }
            }
            else if (CategoryComboBox.SelectedIndex >= 1)
            {
                
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

        // TODO: Пофиксить сортировку заметок по категориям.
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNotesList();
            NotesListBox.SelectedIndex = -1;
            ClearFields();
        }
    }
}
