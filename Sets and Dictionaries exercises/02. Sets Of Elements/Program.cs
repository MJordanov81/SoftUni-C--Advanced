using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var listOne = new HashSet<int>();
            var listTwo = new HashSet<int>();

            for (int i = 0; i < count[0]; i++)
            {
                listOne.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < count[1]; i++)
            {
                listTwo.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in listOne)
            {
                if (listTwo.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
