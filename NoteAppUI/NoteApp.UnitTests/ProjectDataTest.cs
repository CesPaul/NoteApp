namespace NoteApp.UnitTests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// Summary description for ProjectDataTest
    /// </summary>
    [TestFixture]
    public class NotesTest
    {
        [Test(Description = "Позитивный тест геттера Notes")]
        public void TestNotesGet_CorrectValue()
        {
            var expected = new List<Note>();
            expected.Add(new Note("default name", "default content", NoteCategory.Other));

            var projectData = new ProjectData();
            projectData.Notes.Add(new Note("default name", "default content", NoteCategory.Other));
            var actual = projectData.Notes;

            Assert.AreEqual(expected[0].Name, actual[0].Name);
            Assert.AreEqual(expected[0].Content, actual[0].Content);
            Assert.AreEqual(expected[0].Category, actual[0].Category);
        }
    }
}
