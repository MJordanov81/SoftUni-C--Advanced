using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var vips = new SortedSet<string>();
            var regulars = new SortedSet<string>();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Add(input);
                }
                else
                {
                    regulars.Add(input);
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Remove(input);
                }
                else
                {
                    regulars.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vips.Count + regulars.Count);

            if (vips.Count > 0)
            {
                foreach (var guest in vips)
                {
                    Console.WriteLine(guest);
                }
                
            }

            if (regulars.Count > 0)
            {
                foreach (var guest in regulars)
                {
                    Console.WriteLine(guest);
                }

            }
        }
    }
}
