using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var list = new SortedSet<string>();

            while (input != "END")
            {
                var inputParams = Regex.Split(input, ", ");

                if (inputParams[0] == "IN")
                {
                    list.Add(inputParams[1]);
                }

                else
                {
                    list.Remove(inputParams[1]);
                }

                input = Console.ReadLine();
            }

            if (list.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in list)
            {
                Console.WriteLine(car);
            }
        }
    }
}
