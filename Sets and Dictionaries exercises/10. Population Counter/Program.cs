using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Country>();

            var input = Console.ReadLine();

            while (input != "report")
            {
                var inputArray = input.Split('|');
                var city = inputArray[0];
                var country = inputArray[1];
                var population = long.Parse(inputArray[2]);

                if (!list.ContainsKey(country))
                {
                    list[country] = new Country()
                    {
                        Name = country,
                        Cities = new Dictionary<string, long>(),
                        Population = 0
                    };
                }

                list[country].Cities.Add(city, population);
                list[country].Population += population;

                input = Console.ReadLine();
            }

            foreach (var pair in list.OrderByDescending(x => x.Value.Population))
            {
                Console.WriteLine($"{pair.Value.Name} (total population: {pair.Value.Population})");

                foreach (var city in pair.Value.Cities.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }

    public class Country
    {
        public string Name { get ; set; }
        public Dictionary<string, long> Cities { get; set; }
        public long Population { get; set; }
    }
}
