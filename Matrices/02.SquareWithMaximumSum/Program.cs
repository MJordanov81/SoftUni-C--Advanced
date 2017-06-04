using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var matrix = new int[int.Parse(input[0])][];

            for (int i = 0; i < matrix.Length; i++)
            {
                var matrixRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = matrixRow;
            }

            int [] result = new int[2];
            var sum = int.MinValue;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var currentSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] +
                                     matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        result[0] = rowIndex;
                        result[1] = colIndex;                  
                    }
                }
            }

            for (int i = result[0]; i <= result[0] + 1; i++)
            {
                for (int j = result[1]; j <= result[1] + 1; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(sum);
        }
    }
}
