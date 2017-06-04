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
        public static int GetFibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
