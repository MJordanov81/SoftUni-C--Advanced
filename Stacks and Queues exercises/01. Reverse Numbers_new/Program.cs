using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers_new
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            try
            {
                var numbers = input.Split().Select(int.Parse).ToList();

                var stack = new Stack<int>();

                numbers.ForEach(n => stack.Push(n));

                foreach (var number in stack)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine(input);
            }
        }
    }
}
