using System;
using System.Collections.Generic;

namespace NoteApp
{
    /// <summary>
    /// Класс, который хранит словарь всех созданных заметок.
    /// </summary>
    public class ProjectData
    {
        private List<Note> _notes = new List<Note>();
        
        public List<Note> Notes
        {
            get { return _notes; }
        }

        /// <summary>
        /// Хранит текущую заметку
        /// </summary>
        public Note CurrentNote { get; set; }

        /*public string Filename
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
        }*/

    }
}
