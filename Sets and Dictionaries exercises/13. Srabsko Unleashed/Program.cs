using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.Srabsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Venue>();
            var input = Console.ReadLine();

            while (input != "End")
            {
                var pattern = @"^((\w+\s){1,3})@(\D+\s){1,3}(\d+)\s(\d+)";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    var singer = match.Groups[1].Value.Trim();
                    var venue = match.Groups[3].Value.Trim();
                    var price = int.Parse(match.Groups[4].Value);
                    var tickets = int.Parse(match.Groups[5].Value);

                    if (!list.ContainsKey(venue))
                    {
                        list[venue] = new Venue()
                        {
                            Name = venue,
                            Singers = new Dictionary<string, long>()
                        };
                    }

                    if (!list[venue].Singers.ContainsKey(singer))
                    {
                        list[venue].Singers[singer] = 0;
                    }

                    list[venue].Singers[singer] += tickets * price;
                }

                input = Console.ReadLine();

            }

            foreach (var pair in list)
            {
                Console.WriteLine(pair.Key);
                foreach (var singer in pair.Value.Singers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }

    public class Venue
    {
        public string Name { get; set; }
        public Dictionary<string, long> Singers { get; set; }
    }
}
