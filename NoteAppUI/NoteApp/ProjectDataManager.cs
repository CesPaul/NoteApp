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
        /// <param name="filename"></param>
        public static void SaveToFile(ProjectData data, string filename)
        {
            File.WriteAllText(_pathToFile, JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Загружает объект проекта из файла.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static ProjectData LoadFromFile(string filename)
        {
            ProjectData projectData;
            string data;

            try
            {
                data = File.ReadAllText(_pathToFile);
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }

            catch (FileNotFoundException e)
            {
                throw e;
            }

            projectData = JsonConvert.DeserializeObject<ProjectData>(data);

            return projectData;
        }
    }
}
