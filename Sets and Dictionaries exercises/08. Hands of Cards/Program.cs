using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace _08.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Dictionary<string, Hands>();

            var input = Console.ReadLine();

            while (input != "JOKER")
            {
                var inputArray = input.Split(':');
                var name = inputArray[0];

                if (!list.ContainsKey(name))
                {
                    list.Add(name, new Hands());
                }

                var cards = inputArray[1].Split(new [] {',', ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var card in cards)
                {
                    list[name].HandsList.Add(card);
                }
            
                input = Console.ReadLine();
            }

            foreach (var pair in list)
            {
                var handSum = 0;

                foreach (var hand in pair.Value.HandsList)
                {                   
                    var power = 0;
                    try
                    {
                        if (hand.Length < 3)
                        {
                            power = int.Parse(hand[0].ToString());
                        }

                        else
                        {
                            power = int.Parse(hand.Substring(0, 2));
                        }

                    }

                    catch (Exception)
                    {
                        switch (hand[0])
                        {
                            case 'J':
                                power = 11;
                                break;
                            case 'Q':
                                power = 12;
                                break;
                            case 'K':
                                power = 13;
                                break;
                            case 'A':
                                power = 14;
                                break;
                        }
                    }

                    var type = 0;

                    switch (hand.Last())
                    {
                        case 'S':
                            type = 4;
                            break;
                        case 'H':
                            type = 3;
                            break;
                        case 'D':
                            type = 2;
                            break;
                        case 'C':
                            type = 1;
                            break;
                    }

                    handSum += power * type;                  
                }

                pair.Value.HandsSum = handSum;
            }

            foreach (var person in list)
            {
                Console.WriteLine($"{person.Key}: {person.Value.HandsSum}");
            }
        }
    }

    public class Hands
    {
        public HashSet<string> HandsList = new HashSet<string>();
        public int HandsSum = 0;
    }

}
