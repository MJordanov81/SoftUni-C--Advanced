using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimension[0];
            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = long.MinValue;
            var startElement = new int[2];

            for (int i = 0; i < matrix.Length - 2; i++)
            {
                var currentSum = 0L;
                for (int j = 0; j < matrix[i].Length - 2; j++)
                {
                    currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] + matrix[i + 1][j] + matrix[i + 1][j + 1] +
                                 matrix[i + 1][j + 2] + matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startElement[0] = i;
                        startElement[1] = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = startElement[0]; i <= startElement[0] + 2; i++)
            {
                for (int j = startElement[1]; j <= startElement[1] + 2; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
