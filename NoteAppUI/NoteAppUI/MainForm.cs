using System;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            Form addAndEditNoteForm = new AddAndEditNoteForm();
            addAndEditNoteForm.Show();
        }
    }
}
