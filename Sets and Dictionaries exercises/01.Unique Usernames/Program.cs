using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var list = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var userName = Console.ReadLine();
                list.Add(userName);
            }

            foreach (var userName in list)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
