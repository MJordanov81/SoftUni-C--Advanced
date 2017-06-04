using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var list = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (!list.ContainsKey(character))
                {
                    list.Add(character, 0);
                }

                list[character]++;
            }

            foreach (var pair in list)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
