namespace NoteApp.UnitTests
{
    using System;
    using System.IO;
    using NUnit.Framework;

    /// <summary>
    /// Summary description for ProjectDataManagerTest
    /// </summary>
    [TestFixture]
    public class ProjectManagerTest
    {
        private readonly string _pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.notes";
        private readonly string _pathToDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp";
        private ProjectData _projectData;

        [SetUp]
        public void InitProject()
        {
            _projectData = new ProjectData();
            _projectData.Notes.Add(new Note("default name", "default content", NoteCategory.Other));
        }

        [TearDown]
        public void DeleteFile()
        {
            if (File.Exists(_pathToFile))
            {
                File.Delete(_pathToFile);
            }
        }

        [Test(Description = "Тест сериализации проекта в файл")]
        public void TestProjectManagerSaveToFile()
        {
            ProjectDataManager.SaveToFile(_projectData);
            Assert.True(File.Exists(_pathToFile));
        }

        [Test(Description = "Тест десериализации проекта из файла")]
        public void TestProjectManagerLoadFromFile_CorrectLoad()
        {
            var expectedNoteName = "default name";
            var expectedNoteContent = "default content";
            NoteCategory expectedNoteCategory = NoteCategory.Other;

            ProjectData project = new ProjectData();
            project.Notes.Add(new Note("default name", "default content", NoteCategory.Other));
            ProjectDataManager.SaveToFile(project);

            var actual = ProjectDataManager.LoadFromFile();
            Assert.AreEqual(expectedNoteName, actual.Notes[0].Name);
            Assert.AreEqual(expectedNoteContent, actual.Notes[0].Content);
            Assert.AreEqual(expectedNoteCategory, actual.Notes[0].Category);
        }

        [Test(Description = "Тест десериализации проекта без файла сохранения ")]
        public void TestProjectManagerLoadFromFile_WithoutFile()
        {
            if (File.Exists(_pathToFile))
            {
                File.Delete(_pathToFile);
            }

            var expected = 0;

            var project = ProjectDataManager.LoadFromFile();
            var actual = project.Notes.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест десериализации проекта без директории для файла сохранения")]
        public void TestProjectManagerLoadFromFile_WithoutDirectory()
        {
            if (File.Exists(_pathToDirectory))
            {
                File.Delete(_pathToDirectory);
            }

            var expected = 0;

            var project = ProjectDataManager.LoadFromFile();
            var actual = project.Notes.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
