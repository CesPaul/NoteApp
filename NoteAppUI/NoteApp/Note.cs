using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace NoteApp
{
    /// <summary>
    /// Класс, представляющий заметку
    /// </summary>
    public class Note : ICloneable
    {
        private string _name;

        private string _content;

        private NoteCategory _category;

        private DateTime _dateOfCreation;

        private DateTime _dateOfLastEdit;

        public string Name
        {
            get { return _name; }
            set
            {
                string pattern = @"^[a-zA-Z0-9_-]*$";

                if (value == null)
                {
                    throw new ArgumentException("Name value is instance of null type");
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException("Name length is 0 symbols");
                }

                else if (value.Length != 0 && value.Length > 70)
                {
                    throw new ArgumentException("Name length is more than 70 symbols");
                }
                else if (value[0].ToString() == " ")
                {
                    throw new ArgumentException("Name value starts with space symbol");
                }
                else if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Name value contains special symbols");
                }

                else
                {
                    _name = value;
                }
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Content value is instance of null type");
                }

                if (value.Length == 0)
                {
                    throw new ArgumentException("Content value is zero symbols");
                }

                else if (value.Length != 0 && value.Length > 4096)
                {
                    throw new ArgumentException("Content lenth is more than 4096 symbols");
                }

                else if (value[0].ToString() == " ")
                {
                    throw new ArgumentException("Content value is starts with space symbol");
                }
                else
                {
                    _content = value;
                }
            }
        }

        public NoteCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }

        public DateTime DateOfLastEdit
        {
            get { return _dateOfLastEdit; }
            set { _dateOfLastEdit = value; }
        }

        public Note(string name, string content, NoteCategory category)
        {
            Name = name;
            Content = content;
            Category = category;
            DateOfCreation = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
        }

        public void Edit(string name, string content, NoteCategory category)
        {
            Name = name;
            Content = content;
            DateOfLastEdit = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
