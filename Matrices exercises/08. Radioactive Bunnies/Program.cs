using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _08.Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rowsCount = dimensions[0];

            var matrix = new char [rowsCount][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                var array = Console.ReadLine().ToUpper().ToCharArray();
                matrix[rowIndex] = array;
            }

            var commands = Console.ReadLine().ToUpper().ToCharArray();

            var previousCoordinates = GetCoordinates(matrix);
            var coordinates = new int[2];


            var isKilled = false;
            var escaped = false;

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case 'R':
                        coordinates[1] = previousCoordinates[1] + 1;
                        coordinates[0] = previousCoordinates[0];
                        break;
                    case 'L':
                        coordinates[1] = previousCoordinates[1] - 1;
                        coordinates[0] = previousCoordinates[0];
                        break;
                    case 'U':
                        coordinates[0] = previousCoordinates[0] - 1;
                        coordinates[1] = previousCoordinates[1];
                        break;
                    case 'D':
                        coordinates[0] = previousCoordinates[0] + 1;
                        coordinates[1] = previousCoordinates[1];
                        break;
                }
                  
                escaped = CheckIfEscaped(previousCoordinates, coordinates, matrix);
                if (!escaped)
                {
                    matrix = MovePlayer(matrix, coordinates, previousCoordinates);
                }
                
                matrix = PopulateBunnies(matrix);

                if (!escaped)
                {
                    isKilled = CheckIsKilled(matrix);
                    if (isKilled)
                    {
                        break;
                    }
                }

                else if (escaped)
                {
                    break;
                }

                previousCoordinates[0] = coordinates[0];
                previousCoordinates[1] = coordinates[1];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }

            if (escaped)
            {
                Console.WriteLine($"won: {previousCoordinates[0]} {previousCoordinates[1]}");
            }

            if (isKilled)
            {
                Console.WriteLine($"dead: {coordinates[0]} {coordinates[1]}");
            }
        }

        private static bool CheckIsKilled(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static char[][] PopulateBunnies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i - 1 >= 0 && matrix[i - 1][j] == 'B')
                    {
                        matrix[i][j] = 'Q';

                    }

                    else if (i + 1 < matrix.Length && matrix[i + 1][j] == 'B')
                    {
                        matrix[i][j] = 'Q';
                    }

                    else if (j - 1 >= 0 && matrix[i][j - 1] == 'B')
                    {
                        matrix[i][j] = 'Q';
                    }

                    else if (j + 1 < matrix[i].Length && matrix[i][j + 1] == 'B')
                    {
                        matrix[i][j] = 'Q';
                    }              
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'Q')
                    {
                        matrix[i][j] = 'B';

                    }               
                }
            }

            return matrix;
        }

        private static char[][] MovePlayer(char[][] matrix, int[] coordinates, int[] previousCoordinates)
        {
            if (matrix[coordinates[0]][coordinates[1]] == 'B')
            {
                matrix[previousCoordinates[0]][previousCoordinates[1]] = '.';
            }

            else
            {
                matrix[coordinates[0]][coordinates[1]] = 'P';
                matrix[previousCoordinates[0]][previousCoordinates[1]] = '.';
            }

            return matrix;
        }

        private static bool CheckIfEscaped(int[] previousCoordinates, int[] coordinates, char[][] matrix)
        {
            if (coordinates[0] < 0 || coordinates[0] > matrix.Length - 1)
            {
                matrix[previousCoordinates[0]][previousCoordinates[1]] = '.';
                return true;
            }
            else if (coordinates[1] < 0 || coordinates[1] > matrix[0].Length - 1)
            {
                matrix[previousCoordinates[0]][previousCoordinates[1]] = '.';
                return true;
            }

            return false;
        }

        private static int[] GetCoordinates(char[][] matrix)
        {
            var result = new int[2];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }

            return result;
        }
    }
}
