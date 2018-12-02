using System;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        // private ProjectData _projectData;

        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            // _projectData = ProjectDataManager.LoadFromFile("file.txt");
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            Form addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.ShowDialog();
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            // Form addAndEditNoteForm = new AddAndEditNoteForm(_projectData.NotesCollection[0]);
            // addAndEditNoteForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }
}
