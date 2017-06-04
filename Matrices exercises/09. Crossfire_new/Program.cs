using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            var rowsCount = dimensions[0];
            var colsCount = dimensions[1];

            var matrix = new long[rowsCount][];

            FillMatrix(matrix, colsCount);

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var commandArray = command.Split().Select(long.Parse).ToArray();
                var row = commandArray[0];
                var col = commandArray[1];
                var radius = commandArray[2];

                var colStart = (col - radius >= 0) ? col - radius : 0;
                var colEnd = (col + radius <= colsCount - 1) ? col + radius : colsCount - 1;

                var rowStart = (row - radius >= 0) ? row - radius : 0;
                var rowEnd = (row + radius <= rowsCount - 1) ? row + radius : rowsCount - 1;

                if (0 <= row && row <= rowsCount - 1)
                {
                    for (long colsIndex = colStart; colsIndex <= colEnd; colsIndex++)
                    {
                        matrix[row][colsIndex] = 0;
                    }
                }

                if (0 <= col && col <= colsCount - 1)
                {
                    for (long rowIndex = rowStart; rowIndex <= rowEnd; rowIndex++)
                    {
                        matrix[rowIndex][col] = 0;
                    }
                }

                for (long rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
                {
                    var index = 0;
                    var tempArray = new long[colsCount];
                    for (long colsIndex = 0; colsIndex < matrix[rowsIndex].Length; colsIndex++)
                    {
                        if (matrix[rowsIndex][colsIndex] != 0)
                        {
                            tempArray[index] = matrix[rowsIndex][colsIndex];
                            index++;
                        }
                    }

                    matrix[rowsIndex] = tempArray;
                }


                matrix = matrix.Where(x => x.Any(y => y != 0)).ToArray();

                command = Console.ReadLine();
            }

            PrlongMatrix(matrix);
        }

        private static void PrlongMatrix(long[][] matrix)
        {
            for (long rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                var list = new List<long>();
                for (long colsIndex = 0; colsIndex < matrix[rowsIndex].Length; colsIndex++)
                {

                    if (matrix[rowsIndex][colsIndex] != 0)
                    {
                        list.Add(matrix[rowsIndex][colsIndex]);
                    }
                }

                Console.WriteLine(String.Join(" ", list));                
            }
        }

        private static void FillMatrix(long[][] matrix, long colsCount)
        {
            var number = 1;

            for (long rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                var list = new List<long>();

                for (long colsIndex = 0; colsIndex < colsCount; colsIndex++)
                {
                    list.Add(number);
                    number++;
                }

                matrix[rowsIndex] = list.ToArray();
            }
        }
    }
}
