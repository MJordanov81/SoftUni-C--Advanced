using System;
using System.Linq;

namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = long.Parse(Console.ReadLine());

            var matrix = new long[size][];
            long firstDiagonal = 0, secondDiagonal = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                var row = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                matrix[i] = row;
                firstDiagonal += matrix[i][i];
                secondDiagonal += matrix[i][matrix.Length - 1 - i];
            }

            var difference = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(difference);
        }
    }
}
