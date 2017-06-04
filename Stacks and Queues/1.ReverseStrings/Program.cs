using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            var count = stack.Count;

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
