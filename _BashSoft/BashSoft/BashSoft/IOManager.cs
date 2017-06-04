using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subfolders = new Queue<string>();
            subfolders.Enqueue(SessionData.currentPath);

            while (subfolders.Count > 0)
            {
                string currentPath = subfolders.Dequeue();
                
                int identation = currentPath.Split('\\').Length - initialIdentation;

                OutputWriter.WriteMessage(new string('-', identation));
                OutputWriter.WriteMessage(currentPath);
                OutputWriter.WriteEmptyLine();

                string folderLength = new string('-', currentPath.Length);

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var fileName = file.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last().ToString();
                        OutputWriter.WriteMessageOnNewLine(folderLength + "\\" + fileName);
                    }

                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subfolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedExceptionMessage);
                }


                if (identation == depth)
                {
                    break;
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + '\\' + name;
            Directory.CreateDirectory(path);
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf('\\');
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                string newPath = currentPath + '\\' + relativePath;
                currentPath = newPath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            } 
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            else
            {
                SessionData.currentPath = absolutePath;
            }
        }
    }
}