using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            int result = 0;
            string sign = string.Empty;
            int number = 0;

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    number = int.Parse(input[i]);
                }
                catch (Exception)
                {

                    sign = input[i];
                    number = 0;
                }

                if (i == 0)
                {
                    result = number;
                }

                else
                {
                    if (sign == "+")
                    {
                        result += number;
                    }
                    else
                    {
                        result -= number;
                    }
                }         
            }

            Console.WriteLine(result);        
        }
    }
}
