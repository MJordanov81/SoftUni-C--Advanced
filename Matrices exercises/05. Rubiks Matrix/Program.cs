using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = dimension[0];
            var cols = dimension[1];

            var matrix = new int[rows, cols];

            var multiplier = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (j + 1) + multiplier;
                }

                multiplier += cols;
            }

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var index = int.Parse(command[0]);
                var direction = command[1];
                var times = int.Parse(command[2]);

                switch (direction)
                {
                    case "left": matrix = TurnLeft(matrix, index, times);
                        break;
                    case "right": matrix = TurnRight(matrix, index, times);
                        break;
                    case "up": matrix = TurnUp(matrix, index, times);
                        break;
                    case "down": matrix = TurnDown(matrix, index, times);
                        break;
                }
            }

            var number = 1;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[j, k] != number)
                    {
                        var tempNumber = matrix[j, k];
                        matrix[j, k] = number;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int l = 0; l < matrix.GetLength(1); l++)
                            {
                                if (!(i == j && l == k) && matrix[i, l] == number)
                                {
                                    Console.WriteLine($"Swap ({j}, {k}) with ({i}, {l})");
                                    matrix[i, l] = tempNumber;
                                    break;                                  
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    number++;
                }
            }
        }

        public static int[,] TurnLeft(int[,] matrix, int row, int times)
        {
            times = times % matrix.GetLength(0);

            for (int n = 0; n < times; n++)
            {
                var temp = matrix[row, 0];
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    matrix[row, i] = matrix[row, i + 1];
                }
                matrix[row, matrix.GetLength(1) - 1] = temp;
            }

            return matrix;
        }

        public static int[,] TurnRight(int[,] matrix, int row, int times)
        {
            times = times % matrix.GetLength(0);

            for (int n = 0; n < times; n++)
            {
                var temp = matrix[row, matrix.GetLength(1) - 1];
                for (int i = matrix.GetLength(1) - 1; i > 0; i--)
                {
                    matrix[row, i] = matrix[row, i - 1];
                }
                matrix[row, 0] = temp;
            }

            return matrix;
        }

        public static int[,] TurnUp(int[,] matrix, int column, int times)
        {

            times = times % matrix.GetLength(1);

            for (int n = 0; n < times; n++)
            {
                var temp = matrix[0, column];
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    matrix[i, column] = matrix[i + 1, column];
                }
                matrix[matrix.GetLength(0) - 1, column] = temp;
            }

            return matrix;
        }

        public static int[,] TurnDown(int[,] matrix, int column, int times)
        {
            times = times % matrix.GetLength(1);

            for (int n = 0; n < times; n++)
            {
                var temp = matrix[matrix.GetLength(0) - 1, column];
                for (int i = matrix.GetLength(1) - 1; i > 0; i--)
                {
                    matrix[i, column] = matrix[i - 1, column];
                }
                matrix[0, column] = temp;
            }

            return matrix;
        }
    }
}
