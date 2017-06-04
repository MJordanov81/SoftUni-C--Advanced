using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var list = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                Console.ReadLine()
                    .Split()
                    .ToList()
                    .ForEach(x => list.Add(x));
            }

            Console.WriteLine(String.Join(" ", list.OrderBy(x => x)));
        }
    }
}
