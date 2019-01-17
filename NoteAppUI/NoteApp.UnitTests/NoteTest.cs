namespace NoteApp.UnitTests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// Summary description for NoteTest
    /// </summary>
    [TestFixture]
    public class NoteTest
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note("default name", "default content", NoteCategory.Other);
        }

        [TestCase("default name", "default content", NoteCategory.Other, TestName = "Test of constructor")]
        public void TestNoteConstructor(string expectedName, string expectedContent, NoteCategory expectedCategory)
        {
            Assert.AreEqual(expectedName, _note.Name);
            Assert.AreEqual(expectedContent, _note.Content);
            Assert.AreEqual(expectedCategory, _note.Category);
        }

        [Test(Description = "Тест геттера Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Noname";
            _note.Name = expected;
            var actual = _note.Name;

            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        [Test(Description = "Позитивный тест геттера Content")]
        public void TestContentGet_CorrectValue()
        {
            // Строка, которую ожидаем получить от геттера Content
            var expected = "default content";

            // Подготовительный этап - присвоение свойству значения
            _note.Content = expected;

            // Получаем действительное значение от геттера
            var actual = _note.Content;

            // Метод AreEqual сравнивает два объекта и выбрасывает исключение, если они не равны. Принимает три аргумента:
            // expected - то, что ожидаем получить
            // actual - то, что получилось (действительное значение)
            // строка - выбрасываемое сообщение о неудаче           
            Assert.AreEqual(expected, actual, "Геттер Content возвращает неправильное содержимое");
        }

        [Test(Description = "Тест геттера Category")]
        public void TestCategoryGet_CorrectValue()
        {
            var expected = NoteCategory.Other;
            _note.Category = expected;

            var actual = _note.Category;

            Assert.AreEqual(expected, actual, "Геттер Category возвращает неправильную категорию");
        }

        [Test(Description = "Позитивный тест сеттера Category")]
        public void TestCategorySet_CorrectValue()
        {
            Assert.DoesNotThrow(
                () => { _note.Category = NoteCategory.Other; },
                "Не должно возникать исключения"
            );
        }

        [Test(Description = "Позитивный тест геттера DateOfCreation")]
        public void TestDateOfCreationGet_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.DateOfCreation = expected;

            var actual = _note.DateOfCreation;

            Assert.AreEqual(expected, actual, "Геттер DateOfCreation возвращает неправильное время");
        }

        [Test(Description = "Позитивный тест сеттера DateOfCreation")]
        public void TestDateOfCreationSet_CorrectValue()
        {
            Assert.DoesNotThrow(
                () => { _note.DateOfCreation = DateTime.Now; },
                "Не должно возникать исключения"
            );
        }

        [Test(Description = "Позитивный тест геттера DateOfLastEdit")]
        public void TestDateOfLastEditGet_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.DateOfCreation = expected;

            var actual = _note.DateOfCreation;

            Assert.AreEqual(expected, actual, "Геттер DateOfCreation возвращает неправильное время");
        }

        [Test(Description = "Позитивный тест сеттера DateOfLastEdit")]
        public void TestDateOfLastEditSet_CorrectValue()
        {
            Assert.DoesNotThrow(
                () => { _note.DateOfLastEdit = DateTime.Now; },
                "Не должно возникать исключения"
            );
        }

        [Test(Description = "Тест метода clone()")]
        public void TestNoteClone()
        {
            var expected = _note;
            var actual = (Note)_note.Clone();

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Content, actual.Content);
            Assert.AreEqual(expected.Category, actual.Category);
            Assert.AreEqual(expected.DateOfCreation, actual.DateOfCreation);
            Assert.AreEqual(expected.DateOfLastEdit, actual.DateOfLastEdit);
        }
    }
}
