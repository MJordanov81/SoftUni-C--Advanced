using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {

            /*            IOManager.CreateDirectoryInCurrentFolder("Marian");*/

            /*            StudentsRepository.InitializeData();
                        StudentsRepository.GetStudentScoresFromCoure("Unity", "Ivan");*/

            IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            IOManager.TraverseDirectory(20);

        }
    }
}
