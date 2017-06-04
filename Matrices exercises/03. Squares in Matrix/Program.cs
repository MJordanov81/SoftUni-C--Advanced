using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Squares_in_Matrix
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

            var matrix = new string[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            var count = 0;

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if ((matrix[i][j] == matrix[i][j+1]) && (matrix[i][j] == matrix[i+1][j]) && (matrix[i][j] == matrix[i+1][j+1]))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
