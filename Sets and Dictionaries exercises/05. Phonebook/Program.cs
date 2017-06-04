using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneList = new Dictionary<string, string>();
            var input = Console.ReadLine();

            while (input != "search")
            {
                var inputArray = input.Split('-');

                if (!phoneList.ContainsKey(inputArray[0]))
                {
                    phoneList.Add(inputArray[0], string.Empty);
                }

                if (inputArray[1] != null)
                {
                    phoneList[inputArray[0]] = inputArray[1];
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phoneList.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phoneList[input]}");
                }

                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
