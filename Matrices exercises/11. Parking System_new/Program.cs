using System;
using System.Collections.Generic;
using System.Linq;


namespace _11.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            var matrix = new int[dimensions[0]][];
            var input = Console.ReadLine();

            while (input != "stop")
            {
                var inputArray = input.Split().Select(int.Parse)
                    .ToArray();

                var entranceRow = inputArray[0];
                var parkRow = inputArray[1];

                if (matrix[parkRow] == null)
                {
                    matrix[parkRow] = new int[dimensions[1]];
                    matrix[parkRow][0] = 3; //3 cannot be parked on that spot
                }

                var parkCol = inputArray[2];

                if (matrix[parkRow][parkCol] == 1)
                {
                    var emptyLeft = 0;
                    var emptyRight = dimensions[1];

                    var correction = 1;
                    while (parkCol - correction >= 1)
                    {
                        if (matrix[parkRow][parkCol - correction] == 0)
                        {
                            emptyLeft = parkCol - correction;
                            break;
                        }

                        correction++;
                    }

                    correction = 1;
                    while (parkCol + correction <= dimensions[1] - 1)
                    {
                        if (matrix[parkRow][parkCol + correction] == 0)
                        {
                            emptyRight = parkCol + correction;
                            break;
                        }

                        correction++;
                    }

                    if (emptyLeft == 0 && emptyRight == dimensions[1])
                    {
                        Console.WriteLine($"Row {parkRow} full");
                        input = Console.ReadLine();
                        continue;
                    }

                    if (emptyLeft != 0 && emptyRight != dimensions[1])
                    {
                        parkCol = (Math.Abs(emptyLeft - parkCol) <= Math.Abs(emptyRight - parkCol))
                            ? emptyLeft
                            : emptyRight;
                    }

                    else if ((emptyLeft != 0 && emptyRight == dimensions[1]) 
                        || (emptyLeft == 0 && emptyRight != dimensions[1]))
                    {
                        parkCol = (emptyLeft != 0) ? emptyLeft : emptyRight;
                    }
                }

                matrix[parkRow][parkCol] = 1;

                Console.WriteLine(parkCol + 1 + Math.Abs(parkRow - entranceRow));

                input = Console.ReadLine();
            }
        }
    }
}
