using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, User>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();

                var ip = input[0];
                var name = input[1];
                var duration = int.Parse(input[2]);

                if (!list.ContainsKey(name))
                {
                    list.Add(name, new User()
                    {
                        Name = name,
                        IpList = new SortedSet<string>(),
                        Duration = 0
                    });
                }

                list[name].IpList.Add(ip);
                list[name].Duration += duration;
            }

            foreach (var pair in list.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Value.Name}: {pair.Value.Duration} [{String.Join(", ", pair.Value.IpList)}]");
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public SortedSet<string> IpList { get; set; }
        public long Duration { get; set; }
    }
}
