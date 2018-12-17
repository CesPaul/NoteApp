using System;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class AddTestNoteForm : Form
    {
        private Note _currentNote;
        private NoteCategory _currentCategory;

        public NoteCategory CurrentCategory { get => _currentCategory; set => _currentCategory = value; }
        NoteCategory noteCategory;
        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }

        public AddTestNoteForm()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CurrentNote = new Note("Test", "Test", noteCategory);
            Close();
        }

        public void AddNote()
        {
            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
            CreatedDateTimePicker.Value = DateTime.Now;
            ModifiedDateTimePicker.Value = DateTime.Now;
        }
    }

}
