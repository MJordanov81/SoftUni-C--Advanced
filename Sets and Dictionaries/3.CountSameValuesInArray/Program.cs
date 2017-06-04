using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var numbers = Console.ReadLine().Trim().Split().Select(double.Parse).OrderBy(x => x).ToList();

                while (numbers.Count > 0)
                {
                    var currentNumber = numbers[0];
                    var count = 0;
                    foreach (var number in numbers)
                    {
                        if (number == currentNumber)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine(currentNumber + " - " + count + " times");

                    numbers.RemoveAll(x => x == currentNumber);
                }
            }

            catch (Exception)
            {
                return;
            }

        }
    }
}
