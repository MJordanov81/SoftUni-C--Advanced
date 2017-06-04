using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _11.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rowsCount = dimensions[0];
            var colsCount = dimensions[1];

            var distance = 0;

            var matrix = new int[rowsCount][];
            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                var array = new int[colsCount];
                array[0] = 3; //3 cannot be parked on that spot

                matrix[rowsIndex] = array;
            }

            var input = Console.ReadLine();
            var isRowFull = false;

            while (input != "stop")
            {
                var inputArray = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                var entranceRow = inputArray[0];
                var parkRow = inputArray[1];
                var parkCol = inputArray[2];

                if (matrix[parkRow][parkCol] == 1)
                {
                    bool changeDirection = true;
                    bool isNegative = true;
                    int count = 0;
                    while (true)
                    {
                        if (isNegative)
                        {
                            count++;
                                                       
                        }

                        if (changeDirection)
                        {
                            count *= -1;
                        }
                    
                        if (parkCol + count > matrix[parkRow].Length - 1)
                        {
                            Console.WriteLine($"Row {parkRow} full");
                            input = Console.ReadLine();
                            isRowFull = true;
                            break;
                        }

                        if (matrix[parkRow][parkCol + count] != 1 && matrix[parkRow][parkCol + count] != 3)
                        {
                            parkCol = parkCol + count;
                            break;
                        }

                        if (matrix[parkRow][parkCol + count] == 3)
                        {
                            changeDirection = false;
                            isNegative = !isNegative;
                            count *= -1;
                            count--;
                        }

                        if (changeDirection)
                        {
                            isNegative = !isNegative;
                        }

                        if (!isNegative && !changeDirection)
                        {
                            count++;
                        }

                    }


/*                    var freeSpots = new Dictionary<int, int>();
                    for (int colIndex = 1; colIndex < colsCount; colIndex++)
                    {
                        if (matrix[parkRow][colIndex] == 0)
                        {
                            freeSpots[colIndex] = Math.Abs(parkCol - colIndex);
                        }
                    }

                    if (freeSpots.Count > 0)
                    {
                        var newParkCol = freeSpots.OrderBy(x => x.Value)
                            .Take(1)
                            .ToDictionary(x => x.Key, y => y.Value);

                        foreach (var element in newParkCol)
                        {
                            parkCol = element.Key;
                        }
                    }*/
/*                    else
                    {
                        Console.WriteLine($"Row {parkRow} full");
                        input = Console.ReadLine();
                        continue;
                    }*/
                    
                }

                if (!isRowFull)
                {
                    matrix[parkRow][parkCol] = 1;

                    distance = parkCol + 1 + Math.Abs(parkRow - entranceRow);

                    Console.WriteLine(distance);

                    input = Console.ReadLine();
                }
            }
        }
    }
}
