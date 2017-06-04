using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var nFibonacci = int.Parse(Console.ReadLine());

            if (nFibonacci < 3)
            {
                Console.WriteLine("1");
                return;
            }

            var previousPair = new long[] {1L, 1L};

            for (var i = 0; i < nFibonacci - 2; i++)
            {
                var currentNumber = previousPair.Sum();
                previousPair[0] = previousPair[1];
                previousPair[1] = currentNumber;

                if (i == nFibonacci - 3)
                {
                    Console.WriteLine(currentNumber);
                }
            }                 
        }
    }
}
