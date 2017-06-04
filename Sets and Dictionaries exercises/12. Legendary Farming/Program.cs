using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            var list = new Dictionary<string, Material>();

            while (true)
            {
                var input = Console.ReadLine().Trim().Split(new [] {' ', ',', '\t'});

                for (int i = 0; i < input.Length; i+=2)
                {
                    var material = input[i+1].ToLower();
                    var quantity = int.Parse(input[i]);

                    if (!list.ContainsKey(material))
                    {
                        list[material] = new Material()
                        {
                            Name = material
                        };
                    }

                    list[material].Quantity += quantity;

                    if (list[material].ItemObtained())
                    {
                        list[material].Quantity -= 250;
                        PrintOutReport(list, material);
                    }
                }
            }
        }

        public static void PrintOutReport(Dictionary<string, Material> input, string material)
        {

            var materials = new []{ "fragments", "motes", "shards" };

            foreach (var element in materials)
            {
                if (!input.ContainsKey(element))
                {
                    input[element] = new Material()
                    {
                        Name = material,
                        Quantity = 0
                    };
                }
            }


            var item = string.Empty;

            switch (material)
            {
                case "shards":
                    item = "Shadowmourne";
                    break;
                case "fragments":
                    item = "Valanyr";
                    break;
                case "motes":
                    item = "Dragonwrath";
                    break;
            }

            Console.WriteLine($"{item} obtained!");

            foreach (var pair in input
                                .OrderByDescending(x => x.Value.Quantity)
                                .ThenBy(x => x.Value.Name)
                                .ToDictionary(x => x.Key, y => y.Value))
            {
                if (pair.Key == "motes" || pair.Key == "shards" || pair.Key == "fragments")
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value.Quantity}");
                }               
            }

            foreach (var pair in input
                                .OrderBy(x => x.Value.Name)
                                .ToDictionary(x => x.Key, y => y.Value))
            {
                if (pair.Key != "motes" && pair.Key != "shards" && pair.Key != "fragments")
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value.Quantity}");
                }
            }
        }
    }

    public class Material
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool ItemObtained()
        {
            return Quantity >= 250;
        }
    }
}
