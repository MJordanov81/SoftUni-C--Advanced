using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, List<Dragon>>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var type = input[0];
                var name = input[1];

                var damage = (input[2] != "null") ? int.Parse(input[2]) : 45;
                var health = (input[3] != "null") ? int.Parse(input[3]) : 250;
                var armor = (input[4] != "null") ? int.Parse(input[4]) : 10;

                var dragon = new Dragon()
                {
                    Type = type,
                    Name = name,
                    Damage = damage,
                    Health = health,
                    Armor = armor
                };

                list = Dragon.AddDragon(dragon, list);
            }

            foreach (var element in list)
            {
                var avrgDamage = AverageValue(element.Value, "damage").ToString("F");
                var avrgHealth= AverageValue(element.Value, "health").ToString("F");
                var avrgArmor = AverageValue(element.Value, "armor").ToString("F");

                Console.WriteLine($"{element.Key}::({avrgDamage}/{avrgHealth}/{avrgArmor})");
                foreach (var dragon in element.Value)
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }

        public static double AverageValue(List<Dragon> dragons, string query)
        {
            var result = 0d;

            foreach (var element in dragons)
            {
                switch (query)
                {
                    case "damage": result += element.Damage;
                        break;
                    case "health":
                        result += element.Health;
                        break;
                    case "armor":
                        result += element.Armor;
                        break;
                }                
            }

            return result / dragons.Count;
        }
    }

    public class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public static Dictionary<string, List<Dragon>> AddDragon (Dragon dragon, Dictionary<string, List<Dragon>> list)
        {
            if (!list.ContainsKey(dragon.Type))
            {
                list[dragon.Type] = new List<Dragon>();

            }

            bool dragonExists = false;
            var index = 0;

            foreach (var element in list[dragon.Type])
            {
                if (element.Name == dragon.Name)
                {
                    dragonExists = true;
                    break;
                }

                index++;
            }

            if (dragonExists)
            {
                list[dragon.Type][index] = dragon;
            }

            else
            {
                list[dragon.Type].Add(dragon);
            }

            list[dragon.Type] = list[dragon.Type].OrderBy(x => x.Name).ToList();

            return list;
        }
    }
}
