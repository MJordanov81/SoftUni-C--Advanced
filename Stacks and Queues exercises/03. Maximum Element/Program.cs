using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var max = int.MinValue;

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);

                    if (input[1] > max)
                    {
                        max = input[1];
                    }
                }

                else if (input[0] == 2)
                {
                    stack.Pop();
                    max = stack.Max();
                }

                else
                {
                    Console.WriteLine(max);
                }              
            }
        }
    }
}
