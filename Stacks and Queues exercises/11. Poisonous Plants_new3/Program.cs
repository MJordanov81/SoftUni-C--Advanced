using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants_new3
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsNumber = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var DaysPlantsDie = new int[plantsNumber];
            var previousPlants = new Stack<int>();
            previousPlants.Push(0);

            for (int i = 1; i < plantsNumber; i++)
            {
                int lastDay = 0;
                while (previousPlants.Count() > 0 && plants[previousPlants.Peek()] >= plants[i])
                {
                    lastDay = Math.Max(lastDay, DaysPlantsDie[previousPlants.Pop()]);
                }

                if (previousPlants.Count() > 0)
                {
                    DaysPlantsDie[i] = lastDay + 1;
                }

                previousPlants.Push(i);
            }

            Console.WriteLine(DaysPlantsDie.Max());
        }
    }
}
