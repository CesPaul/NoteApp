using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;

namespace NoteApp
{
    public class Project
    {
        private List<Note> _notesCollection = new List<Note>();

        private string _filename;

        public Project(string filename)
        {
            filename = filename;
        }

        public string Filename
        {
            get { return _filename; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Lenth of filename contains 0 symbols");
                }
                else if (value.Length != 0 && value.Length > 25)
                {
                    throw new ArgumentException("Lenth of name content more than 25 symbols");
                }
                else
                {
                    _filename = value;
                }
            }
        }

        public List<Note> NotesCollection
        {
            get { return _notesCollection; }
        }
    }
}
