using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool IsDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!IsDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }

            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var tokens = input.Split();
                var course = tokens[0];
                var name = tokens[1];
                var mark = int.Parse(tokens[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse[course] = new Dictionary<string, List<int>>();
                }

                if (!studentsByCourse[course].ContainsKey(name))
                {
                    studentsByCourse[course][name] = new List<int>();
                }

                studentsByCourse[course][name].Add(mark);

                input = Console.ReadLine();
            }

            IsDataInitialized = true;
            Console.WriteLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (IsDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingCourseInDatabase);
                }               
            }

            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsByCourse[courseName].ContainsKey(studentUserName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingStudentInDataBase);
                }
            }

            return false;
        }

        public static void GetStudentScoresFromCoure(string courseName, string userName)
        {
            if (IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                var students = studentsByCourse[courseName];

                foreach (var student in students)
                {
                    OutputWriter.PrintStudent(student);
                }
            }

        }
    }
}