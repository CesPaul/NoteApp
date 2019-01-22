using System.Collections.Generic;
using System.Linq;

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
            set => _notes = value;
        }

        /// <summary>
        /// Хранит текущую заметку
        /// </summary>
        public Note CurrentNote { get; set; }

        /// <summary>
        /// Организовать список по дате создания заметок
        /// </summary>
        /// <returns>Список отсортированных заметок</returns>
        public List<Note> OrderListByEditDate()
        {
            return Notes.OrderByDescending(t => t.DateOfLastEdit).ToList();
        }

        /// <summary>
        /// Организовать список заметок по дате создания и отфильтровать по категории
        /// </summary>
        /// <param name="category">Категория заметки</param>
        /// <returns>Список отфильтрованных заметок</returns>
        public List<Note> OrderListByEditDate(NoteCategory category)
        {
            return OrderListByEditDate().FindAll(t => t.Category == category);
        }
    }
}
