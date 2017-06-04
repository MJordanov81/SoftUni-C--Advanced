using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var result = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while(input != 0)
            {
                result.Push(input % 2);
                input = input / 2;
            }

            var count = result.Count;

            for (int i = 0; i < count; i++)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();

        }
    }
}
