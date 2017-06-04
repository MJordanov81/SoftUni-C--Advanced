using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.The_Heigan_Dance_new
{
    class Program
    {
        static void Main(string[] args)
        {
            var damageHeigane = decimal.Parse(Console.ReadLine());

            var position = new[] { 7, 7 };
            var matrix = new int[15][];

            FillMatrix(matrix);

            var healthHeigan = 3000000M;
            var healthPlayer = 18500;

            bool additionalDamageByPlague = false;

            bool isHeiganDead = false;
            bool isPlayerDead = false;

            var lethalSpell = string.Empty;

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


                var spellArray = Console.ReadLine().Split();
                var spellType = spellArray[0];
                var spellCoordinates = new[] { int.Parse(spellArray[1]), int.Parse(spellArray[2]) };

                ImpactMatrix(matrix, spellCoordinates, 1);

                bool playerEscapes = PlayerEscapes(matrix, position, false);

                ImpactMatrix(matrix, spellCoordinates, 0);

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

            PrintResult(isHeiganDead, healthHeigan, isPlayerDead, lethalSpell, healthPlayer, position);
        }

        private static void PrintResult(bool isHeiganDead, decimal healthHeigan, bool isPlayerDead, string lethalSpell,
            int healthPlayer, int[] position)
        {
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

        private static bool PlayerEscapes(int[][] matrix, int[] position, bool playerEscapes)
        {
            if (matrix[position[0]][position[1]] == 1)
            {
                if (position[0] > 0 && matrix[position[0] - 1][position[1]] != 1)
                {
                    playerEscapes = true;
                    position[0] -= 1;
                }
                else if (position[1] < 14 && matrix[position[0]][position[1] + 1] != 1)
                {
                    playerEscapes = true;
                    position[1] += 1;
                }
                else if (position[0] < 14 && matrix[position[0] + 1][position[1]] != 1)
                {
                    playerEscapes = true;
                    position[0] += 1;
                }
                else if (position[1] > 0 && matrix[position[0]][position[1] - 1] != 1)
                {
                    playerEscapes = true;
                    position[1] -= 1;
                }
            }
            else
            {
                playerEscapes = true;
            }
            return playerEscapes;
        }

        private static void FillMatrix(int[][] matrix)
        {
            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                var array = new int[15];
                matrix[rowsIndex] = array;
            }
        }

        private static void ImpactMatrix(int[][] matrix, int[] spellCoordinates, int impact)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        matrix[spellCoordinates[0] + i][spellCoordinates[1] + j] = impact;
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }
    }
}
