namespace NoteApp
{
    /// <summary>
    /// Класс, представляющий возможность клонирования экземпляра.
    /// </summary>
    /// <typeparam name="T"></typeparam>

    // TODO повторить шаблоны.
    interface ICloneable<T>
    {
        T Clone();
    }
}
