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
            var dimension = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = dimension[0];
            var cols = dimension[1];
            var stringInput = Console.ReadLine();
            var impact = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var matrix = new char[rows, cols];
            var k = 0;
            var changeDir = false;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (changeDir)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = stringInput[k];
                        k++;

                        if (k > stringInput.Length - 1)
                        {
                            k = 0;
                        }
                    }

                    changeDir = false;
                }

                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = stringInput[k];
                        k++;

                        if (k > stringInput.Length - 1)
                        {
                            k = 0;
                        }
                    }

                    changeDir = true;
                }
                              
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

            var impactRow = impact[0];
            var impactCol = impact[1];
            var impactR = impact[2];

            var corr = impactR;
            for (int i = impactRow - impactR; i <= impactRow + impactR; i++)
            {
                
                for (int j = impactCol - impactR + corr; j <= impactCol + impactR - corr; j++)
                {
                    try
                    {
                        matrix[i, j] = ' ';
                    }

                    catch (Exception)
                    {
                        continue;
                    }
                    
                   
                }

                if (i >= impactRow)
                {
                    corr++;
                }
                else
                {
                    corr--;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }


            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = matrix.GetLength(0) - 1; j > 0; j--)
                {
                    if (matrix[j, i] == ' ')
                    {
                        for (int l = 0; ; l++)
                        {
                            matrix[j, i] = matrix[j - l, i];
                            if (matrix[j, i] != ' ')
                            {
                                matrix[j - l, i] = ' ';
                                break;
                            } else if (j-l == 0)
                            {
                                break;
                            }                          
                        }



                        /*var correction = 0;
                        var value = matrix[j - 1 - correction, i];

                        do
                        {
                            
                            value = matrix[j - 1 - correction, i];
                            correction++;

                        } while (value == ' ' && j - 1 - correction > 0);


                        matrix[j, i] = value;
                        matrix[j - 1 - correction - 1, i] = ' ';*/
                    }
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
