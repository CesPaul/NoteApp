using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public static class ProjectManager
    {
        private static readonly string _pathToFile = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.notes";
    }
}
