using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = Console.ReadLine()
                        .Split(new char[] {' ', ','})
                        .Select(x => int.Parse(x))
                        .ToArray();

            var numbers = Console.ReadLine()
                        .Split(new char[] { ' ', ',' })
                        .Select(x => int.Parse(x))
                        .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < param[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < param[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0 && queue.Contains(param[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }


        }
    }
}
