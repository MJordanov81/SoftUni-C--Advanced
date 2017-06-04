using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = dimension[0];
            var cols = dimension[1];

            var stringInput = Console.ReadLine();

            var impact = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var matrix = new char[rows, cols];

            FillMatrix(matrix, stringInput);

            var impactRow = impact[0];
            var impactCol = impact[1];
            var impactR = impact[2];

            GetImpact(impactR, impactRow, impactCol, matrix);

            var reverseMatrix  = new char [cols][];

            ReverseMatrix(matrix, rows, reverseMatrix);

            PrintMatrix(rows, reverseMatrix);

        }

        private static void GetImpact(int impactR, int impactRow, int impactCol, char[,] matrix)
        {
            // (x - center_x) ^ 2 + (y - center_y) ^ 2 <= radius ^ 2

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((j - impactCol) * (j - impactCol) + (i - impactRow) * (i - impactRow) <= impactR * impactR)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(int rows, char[][] reverseMatrix)
        {
            for (int j = rows - 1; j >= 0; j--)
            {
                for (int i = 0; i < reverseMatrix.Length; i++)
                {
                    if (reverseMatrix[i][j] == '\0')
                    {
                        Console.Write(' ');
                    }

                    else
                    {
                        Console.Write(reverseMatrix[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void ReverseMatrix(char[,] matrix, int rows, char[][] reverseMatrix)
        {
            var index = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var matrixRow = new List<char>();


                for (int l = matrix.GetLength(0) - 1; l >= 0; l--)
                {
                    if (matrix[l, j] != ' ')
                    {
                        matrixRow.Add(matrix[l, j]);
                    }
                }

                var array = new char[rows];

                for (int i = 0; i < matrixRow.Count; i++)
                {
                    array[i] = matrixRow[i];
                }

                reverseMatrix[index] = array;
                index++;
            }
        }

        private static void FillMatrix(char[,] matrix, string stringInput)
        {
            var currentIndex = 0;
            var isMovingRight = false;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (isMovingRight)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (currentIndex > stringInput.Length - 1)
                        {
                            currentIndex = 0;
                        }

                        matrix[i, j] = stringInput[currentIndex];
                        currentIndex++;
                    }
                }

                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (currentIndex > stringInput.Length - 1)
                        {
                            currentIndex = 0;
                        }

                        matrix[i, j] = stringInput[currentIndex];
                        currentIndex++;
                    }
                }

                isMovingRight = !isMovingRight;
            }
        }
    }
}
