using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var list = new SortedDictionary<string, double>();

            for (int i = 0; i < count; i++)
            {
                var name = Console.ReadLine();

                if (!list.ContainsKey(name))
                {
                    list.Add(name, 0);
                }

                var average = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(double.Parse)
                    .ToArray()
                    .Average();

                list[name] = average;
            }

            foreach (var student in list)
            {
                Console.WriteLine(student.Key + " is graduated with " + student.Value);
            }
        }
    }
}
