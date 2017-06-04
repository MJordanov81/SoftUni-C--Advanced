using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, long>();

            while (true)
            {
                var resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (!list.ContainsKey(resource))
                {
                    list.Add(resource, 0);
                }

                list[resource] += quantity;
            }

            foreach (var pair in list)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
