using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants_new
{
    class Program
    {
        static void Main(string[] args)
        {

            var count = int.Parse(Console.ReadLine());
            var pesticides = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(pesticides);

            var day = -1;
            var removed = 0;

            do
            {
                removed = 0;
                var temp = queue.Peek();
                count = queue.Count;
                queue.Enqueue(queue.Dequeue());

                for (int i = 0; i < count - 1; i++)
                {

                    if (temp < queue.Peek())
                    {
                        temp = queue.Dequeue();
                        removed++;
                        continue;
                    }

                    temp = queue.Peek();
                    queue.Enqueue(queue.Dequeue());

                }
                day++;

            } while (removed != 0);

            Console.WriteLine(day);
        }
    }
}
