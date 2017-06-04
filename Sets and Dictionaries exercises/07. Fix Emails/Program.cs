using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if (!(email.EndsWith(".uk") || email.EndsWith(".us")))
                {
                    if (!list.ContainsKey(name))
                    {
                        list[name] = string.Empty;
                    }

                    list[name] = email;
                }
            }

            foreach (var pair in list)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
