using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            var damageHeigane = decimal.Parse(Console.ReadLine());

            var position = new []{7, 7};

            var healthHeigan = 3000000M;
            var healthPlayer = 18500;

            var lethalSpell = string.Empty;

            bool additionalDamageByPlague = false;

            bool isHeiganDead = false;
            bool isPlayerDead = false;


            do
            {
                healthHeigan -= damageHeigane; //Heigan takes damage

                if (healthHeigan <= 0)
                {
                    isHeiganDead = true;
                }

                if (additionalDamageByPlague)
                {
                    healthPlayer -= 3500;
                    additionalDamageByPlague = false;

                    if (healthPlayer <= 0)
                    {
                        lethalSpell = "Cloud";
                        isPlayerDead = true;
                    }
                }

                if (isPlayerDead || isHeiganDead)
                {
                    break;
                }

                var spell = Console.ReadLine().Split();
                var spellType = spell[0];
                var spellCoordinates = new[] {int.Parse(spell[1]), int.Parse(spell[2])};

                bool playerEscapes = false;

                if (position[0] >= spellCoordinates[0] - 1 && position[0] <= spellCoordinates[0] + 1 &&
                    position[1] >= spellCoordinates[1] - 1 && position[1] <= spellCoordinates[1] + 1)
                {

                    if (position[0] == spellCoordinates[0] - 1 && position[0] != 0)
                    {
                        playerEscapes = true;
                        position[0] -= 1;
                    }
                    else if (position[1] == spellCoordinates[1] + 1 && position[1] != 14)
                    {
                        playerEscapes = true;
                        position[1] += 1;

                    }
                    else if (position[0] == spellCoordinates[0] + 1 && position[0] != 14)
                    {
                        playerEscapes = true;
                        position[0] += 1;
                    }
                    else if (position[1] == spellCoordinates[1] + 1 && position[0] != 0)
                    {
                        playerEscapes = true;
                        position[1] -= 1;
                    }

                }
                else
                {
                    playerEscapes = true;
                }

                if (!playerEscapes)
                {
                    if (spellType == "Cloud")
                    {
                        healthPlayer -= 3500;
                        additionalDamageByPlague = true;
                    }

                    else if (spellType == "Eruption")
                    {
                        healthPlayer -= 6000;
                    }
                }

                if (healthPlayer <= 0)
                {
                    lethalSpell = spellType;
                    isPlayerDead = true;
                }


            } while (!isPlayerDead);

            if (isHeiganDead)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }

            else
            {
                Console.WriteLine("Heigan: {0:f2}", healthHeigan);
            }

            if (isPlayerDead)
            {
                if (lethalSpell == "Cloud")
                {
                    lethalSpell = "Plague Cloud";
                }

                Console.WriteLine($"Player: Killed by {lethalSpell}");
            }

            else
            {
                Console.WriteLine($"Player: {healthPlayer}");
            }

            Console.WriteLine($"Final position: {position[0]}, {position[1]}");

        }
    }
}
