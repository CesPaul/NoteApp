using System;
using System.Text.RegularExpressions;
using DateTime = System.DateTime;

namespace NoteApp
{
    /// <summary>
    /// Класс, представляющий заметку.
    /// </summary>
    public class Note : ICloneable
    {
        // Уникальный идентификатор записи.
        //private readonly Guid _id = new Guid();

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
                string pattern = @"^[\w*\s-0-9]*$";

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
            set { _dateOfCreation = value; }
        }

        public DateTime DateOfLastEdit
        {
            get { return _dateOfLastEdit; }
            set { _dateOfLastEdit = value; }
        }

        /// <summary>
        /// Конструктор, который устанавливает значения полей заметки.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="category"></param>
        public Note(string name, string content, NoteCategory category)
        {
            Name = name;
            Content = content;
            Category = category;
            DateOfCreation = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
        }

        /// <summary>
        /// Метод для редактирования заметки.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="category"></param>
        public void Edit(string name, string content, NoteCategory category)
        {
            Name = name;
            Content = content;
            Category = category;
            DateOfLastEdit = DateTime.Now;
        }

        
            // Категория преобразовывается в int, int преобразовывается в NoteCategory.
            // При этом происходит создание нового объекта типа NoteCategory.
            // return new Note(Name, Content, (NoteCategory)((int)Category));

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
