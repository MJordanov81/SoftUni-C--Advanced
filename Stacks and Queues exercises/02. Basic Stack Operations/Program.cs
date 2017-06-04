using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var stack = new Stack<int>();

            for (int i = 0; i < input[0]; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }

            try
            {
                bool IsInStack = stack.Contains(input[2]);

                if (IsInStack)
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("0");
            }

            
        }
    }
}
