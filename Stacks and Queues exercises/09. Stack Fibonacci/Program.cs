using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>(new long [] {0, 1});

            for (int i = 0; i < n - 1; i++)
            {
                var temp = stack.Pop();
                var currentNumber = stack.Pop() + temp;
                stack.Push(temp);
                stack.Push(currentNumber);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
