using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Dictionary<string, int>>();
            var input = Console.ReadLine();

            while (input != "end")
            {
                var inputArray = input.Split();
                var ip = inputArray[0].Remove(0, 3);
                var name = inputArray[2].Remove(0, 5);

                if (!list.ContainsKey(name))
                {
                    list[name] = new Dictionary<string, int>();
                }

                if (!list[name].ContainsKey(ip))
                {
                    list[name][ip] = 0;
                }

                list[name][ip]++;
                input = Console.ReadLine();
            }

            foreach (var pair in list.OrderBy(x => x.Key))
            {
                Console.WriteLine(pair.Key + ": ");

                var count = 0;
                foreach (var ip in pair.Value)
                {
                    count++;
                    if (count == pair.Value.Count)
                    {
                        Console.WriteLine($"{ip.Key} => {ip.Value}.");
                    }
                    else
                    {
                        Console.Write($"{ip.Key} => {ip.Value}, ");
                    }                  
                }
            }
        }
    }
}
