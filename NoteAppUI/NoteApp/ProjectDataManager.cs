using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс, реализующий сохранение в файл и загрузку проекта из файла.
    /// </summary>
    public static class ProjectDataManager
    {
        /// <summary>
        /// Хранит путь до файла сохранения.
        /// </summary>
        private static readonly string _pathToFile = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.notes";

        /// <summary>
        /// Сохраняет объект проекта в файл.
        /// </summary>
        /// <param name="data"></param>
        public static void SaveToFile(ProjectData data)
        {
            using (StreamWriter file = File.CreateText(_pathToFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }

        /// <summary>
        /// Загружает объект проекта из файла.
        /// </summary>
        /// <returns></returns>
        public static ProjectData LoadFromFile()
        {
            try
            {
                using (StreamReader file = File.OpenText(_pathToFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (ProjectData)serializer.Deserialize(file, typeof(ProjectData));
                }
            }
            catch (FileNotFoundException)
            {
                ProjectData projectData = new ProjectData();
                ProjectDataManager.SaveToFile(projectData);

                using (StreamReader file = File.OpenText(_pathToFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (ProjectData)serializer.Deserialize(file, typeof(ProjectData));
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp");

                ProjectData projectData = new ProjectData();
                ProjectDataManager.SaveToFile(projectData);

                using (StreamReader file = File.OpenText(_pathToFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (ProjectData)serializer.Deserialize(file, typeof(ProjectData));
                }
            }
        }
    }
}
