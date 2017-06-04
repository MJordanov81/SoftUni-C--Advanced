using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];

            var matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = (char) (97 + i) + "" + (char) (97 + i + j) + (char) (97 + i) + " ";
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }

        }
    }
}
