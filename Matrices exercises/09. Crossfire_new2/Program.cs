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
            var dimensions = Console.ReadLine().Split()
                .Select(long.Parse).ToArray();

            var rowsCount = dimensions[0];
            var colsCount = dimensions[1];

            var matrix = new short[rowsCount][];

            FillMatrix(matrix, colsCount, rowsCount);

            var command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                var commandArray = command.Split()
                                    .Select(long.Parse).ToArray();

                var row = commandArray[0];
                var col = commandArray[1];
                var radius = commandArray[2];


                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if ((colIndex - col) * (colIndex - col) + (rowIndex - row) * (rowIndex - row) <= radius * radius)
                        {
                            if (colIndex == col || rowIndex == row)
                            {
                                matrix[rowIndex][colIndex] = 0;
                            }
                           
                        }
                    }
                }

                matrix = matrix.Where(x => IsNullable(x) == false).ToArray();

                for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
                {
                    var tempArray = new List<short>();
                    for (int colsIndex = 0; colsIndex < matrix[rowsIndex].Length; colsIndex++)
                    {
                        if (matrix[rowsIndex][colsIndex] != 0)
                        {
                            tempArray.Add(matrix[rowsIndex][colsIndex]);
                        }
                    }

                    matrix[rowsIndex] = tempArray.ToArray();
                }

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static bool IsNullable(short[] list)
        {
            bool result = true;

            foreach (var element in list)
            {
                if (element != 0)
                {
                    result = false;
                }
            }

            return result;
        }

        private static void PrintMatrix(short[][] matrix)
        {
            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                var list = new List<short>();
                for (int colsIndex = 0; colsIndex < matrix[rowsIndex].Length; colsIndex++)
                {

                    if (matrix[rowsIndex][colsIndex] != 0)
                    {
                        list.Add(matrix[rowsIndex][colsIndex]);
                    }
                }

                if (list.Count != 0)
                {
                    Console.WriteLine(string.Join(" ", list));
                }
            }
        }

        private static void FillMatrix(short[][] matrix, long colsCount, long rowsCount)
        {
            short number = 1;

            for (long rowsIndex = 0; rowsIndex < rowsCount; rowsIndex++)
            {
                var list = new short[colsCount];

                for (long colsIndex = 0; colsIndex < colsCount; colsIndex++)
                {
                    list[colsIndex] = number;
                    number++;
                }

                matrix[rowsIndex] = list;
            }
        }
    }
}
