using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            try
            {
                char [] chars = {' ', ','};
                var numbers = input.Trim().Split(chars).Select(int.Parse).ToList();

                var stack = new Stack<int>();

                numbers.ForEach(n => stack.Push(n));

                foreach (var number in stack)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
            catch(Exception)
            {
                Console.WriteLine(input);
            }         
        }
    }
}
