using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);

            Console.Write(n + " ");

            for (int i = 0; i < 16; i++)
            {
                long first = queue.Peek() + 1;
                Console.Write(first + " ");
                queue.Enqueue(first);

                long second = 2 * queue.Peek() + 1;
                Console.Write(second + " ");
                queue.Enqueue(second);

                long third = queue.Dequeue() + 2;
                Console.Write(third + " ");
                queue.Enqueue(third);
            }

            Console.WriteLine(queue.Dequeue() + 1);
        }
    }
}
