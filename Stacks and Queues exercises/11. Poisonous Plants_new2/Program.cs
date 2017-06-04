using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants_new2
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var doses = Console.ReadLine().Split().Select(int.Parse).ToList();

            var indexesToRemove = new SortedSet<int>();
            var day = 0;

            while (true)
            {
                count = doses.Count;
                for (int i = 1; i < count; i++)
                {
                    if (doses[i] > doses[i - 1])
                    {
                        indexesToRemove.Add(i);
                    }
                }

                if (indexesToRemove.Count == 0)
                {
                    break;
                }

                day++;

                var list = new List<int>(indexesToRemove);

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    doses.RemoveAt(list[i]);
                }

                indexesToRemove.Clear();
            }

            Console.WriteLine(day);
        }
    }
}
