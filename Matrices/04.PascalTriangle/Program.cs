using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());

            var matrix = new long[input][];

            var numberColumns = 1;

            for (int i = 0; i < matrix.Length; i++)
            {

                matrix[i] = new long[numberColumns];
                for (int j = 0; j < numberColumns; j++)                    
                {


                    if (j == 0)
                    {
                        matrix[i][j] = 1;
                    }

                    else if (j == numberColumns-1)
                    {
                        matrix[i][j] = 1;
                    }

                    else
                    {
                        if (i == 0)
                        {
                            matrix[i][j] = 1;
                        }

                        matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                    }

                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
                numberColumns++;
            }
        }
    }
}
