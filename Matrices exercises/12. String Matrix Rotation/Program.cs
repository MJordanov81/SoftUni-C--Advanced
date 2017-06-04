using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var degrees = int.Parse(command[1]);

            var tempList = new List<char[]>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var array = input.ToCharArray();
                tempList.Add(array);

                input = Console.ReadLine();
            }

            var longestArray = int.MinValue;

            foreach (var element in tempList)
            {
                if (element.Length > longestArray)
                {
                    longestArray = element.Length;
                }
            }

            var matrix = new char[tempList.Count][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[longestArray];

                var index = 0;
                for (int j = 0; j < tempList[i].Length; j++)
                {
                    matrix[i][j] = tempList[i][j];
                    index = j;
                }

                for (int j = index + 1; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = ' ';
                }
            }

            if (degrees == 90 || (degrees - 90) % 360 == 0)
            {
                var resultMatrix = new char[longestArray, matrix.Length];
                RotateMatrix90(resultMatrix, matrix);
                PrintMatrix(resultMatrix);
               
            }

            if (degrees == 180 || (degrees - 180) % 360 == 0)
            {
                var resultMatrix = new char[matrix.Length, longestArray];
                RotateMatrix180(resultMatrix, matrix);
                PrintMatrix(resultMatrix);

            }

            if (degrees == 270 || (degrees - 270) % 360 == 0)
            {
                var resultMatrix = new char[longestArray, matrix.Length];
                RotateMatrix270(resultMatrix, matrix);
                PrintMatrix(resultMatrix);

            }

            if (degrees == 0 || (degrees - 0) % 360 == 0)
            {

                PrintMatrixOriginal(matrix);

            }


        }

        private static void RotateMatrix270(char[,] resultMatrix, char[][] matrix)
        {
            for (int colIndex = 0; colIndex < resultMatrix.GetLength(1); colIndex++)
            {
                for (int rowIndex = resultMatrix.GetLength(0) - 1; rowIndex >= 0; rowIndex--)
                {
                    resultMatrix[rowIndex, colIndex] = matrix[colIndex][resultMatrix.GetLength(0) - 1 - rowIndex];
                }
            }
        }

        private static void RotateMatrix180(char[,] resultMatrix, char[][] matrix)
        {
            for (int rowIndex = 0; rowIndex < resultMatrix.GetLength(0); rowIndex++)
            {
                var array = matrix[matrix.Length - 1 - rowIndex].Reverse().ToArray();

                for (int colIndex = 0; colIndex < resultMatrix.GetLength(1); colIndex++)
                {
                    resultMatrix[rowIndex, colIndex] = array[colIndex];
                }
            }
        }

        private static void PrintMatrixOriginal(char[][] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    Console.Write(matrix[rowIndex][colIndex]);
                }

                Console.WriteLine();
            }
        }

        private static void RotateMatrix90(char[,] resultMatrix, char[][] matrix)
        {
            for (int colIndex = 0; colIndex < resultMatrix.GetLength(1); colIndex++)
            {
                for (int rowIndex = 0; rowIndex < resultMatrix.GetLength(0); rowIndex++)
                {
                    resultMatrix[rowIndex, colIndex] = matrix[resultMatrix.GetLength(1) - 1 - colIndex][rowIndex];
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    Console.Write(matrix[rowIndex, colIndex]);
                }

                Console.WriteLine();
            }
        }
    }
}
