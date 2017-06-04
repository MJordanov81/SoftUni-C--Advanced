using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());          
            var queue = new Queue<int[]>();

            for (int i = 0; i < count; i++)
            {
                var currentPump = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                
                queue.Enqueue(currentPump);
            }

            var index = 0;

            while (true)
            {
                var fuel = 0L;
                var stops = 1;
                var workingQueue = new Queue<int[]>(queue);

                while (stops != count)
                {
                    var currentStop = workingQueue.Peek();
                    fuel += currentStop[0];

                    if (fuel >= currentStop[1])
                    {
                        workingQueue.Dequeue();
                        fuel -= currentStop[1];
                        stops++;
                    }

                    else
                    {
                        for (int i = 0; i < stops; i++)
                        {
                            queue.Enqueue(queue.Dequeue());
                            index++;
                        }
                        break;
                    }
                }

                if (stops == count)
                {
                    Console.WriteLine(index);
                    break;
                }               
            }           
        }
    }
}
