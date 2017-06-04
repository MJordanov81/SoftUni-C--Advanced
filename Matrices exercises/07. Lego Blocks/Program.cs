using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsCount = int.Parse(Console.ReadLine());

            var matrixOne = FillMatrix(rowsCount, false);
            var matrixTwo = FillMatrix(rowsCount, true);
            var resultMatrix = new int[rowsCount][];

            var previousLength = 0;
            var doMatch = true;
            var cellsCount = 0;

            for (int rowIndex = 0; rowIndex < resultMatrix.Length; rowIndex++)
            {
                var array = new int[matrixOne[rowIndex].Length + matrixTwo[rowIndex].Length];
                Array.Copy(matrixOne[rowIndex], 0, array, 0, matrixOne[rowIndex].Length);
                Array.Copy(matrixTwo[rowIndex], 0, array, matrixOne[rowIndex].Length, matrixTwo[rowIndex].Length);
                resultMatrix[rowIndex] = array;

                if (rowIndex != 0 && array.Length != previousLength)
                {                    
                    doMatch = false;
                }

                previousLength = array.Length;
                cellsCount += array.Length;
            }

            if (doMatch)
            {
                for (int rowIndex = 0; rowIndex < resultMatrix.Length; rowIndex++)
                {
                    var list = new List<int>();
                    for (int colIndex = 0; colIndex < resultMatrix[rowIndex].Length; colIndex++)
                    {
                        list.Add(resultMatrix[rowIndex][colIndex]);
                    }

                    Console.WriteLine("[" + String.Join(", ", list) + "]");
                }
            }

            else
            {
                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
        }

        private static int[][] FillMatrix(int rowsCount, bool doReverse)
        {
            var matrix = new int[rowsCount][];

            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                if (doReverse)
                {
                    var array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).Reverse().ToArray();
                    matrix[rowsIndex] = array;
                }

                else
                {
                    var array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();
                    matrix[rowsIndex] = array;
                }
            }
            return matrix;
        }
    }
}
