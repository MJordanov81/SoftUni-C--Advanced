using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFibonacci.GetFibonacci(n));
        }
    }

    public class CalculateFibonacci
    {
        public static long GetFibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            var queue = new Queue<long>(new [] {1L, 1L});

            for (int i = 0; i < n-2; i++)
            {
                queue.Enqueue(queue.Dequeue() + queue.Peek());
            }

            return queue.Last();
        }
    }
}
