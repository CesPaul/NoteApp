using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        private readonly DateTime _dateOfCreation;

        private DateTime _dateOfLastEdit;

        public string Name
        {
            get { return _name; }
            set
            {
                // TODO Добавить символ пробел в паттерн.
                string pattern = @"^[a-zA-Z0-9_-]*$";

                if (value == null)
                {
                    throw new ArgumentException("Name value is instance of null type");
                }

                value = value.Trim();
                if (value.Length == 0)
                {
                    _name = "Noname";
                    return;
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name length is more than 50 symbols");
                }
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Name value contains special symbols");
                }
                 _name = value;
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
                _content = value.Trim();
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
            _dateOfCreation = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
        }

        public void Edit(string name, string content, NoteCategory category)
        {
            Name = name;
            Content = content;
            Category = category;
            DateOfLastEdit = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
