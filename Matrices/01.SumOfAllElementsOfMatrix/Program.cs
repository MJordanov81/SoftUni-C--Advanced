using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfAllElementsOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var matrix = new int [int.Parse(input[0])][];
            var sum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                var matrixRow = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = matrixRow;
                sum += matrixRow.Sum();
            }

            Console.WriteLine(int.Parse(input[0]));
            Console.WriteLine(int.Parse(input[1]));
            Console.WriteLine(sum);
        }
    }
}
