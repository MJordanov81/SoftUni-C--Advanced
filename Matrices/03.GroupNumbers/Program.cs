using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var result = new Dictionary<int, List<int>>();

            foreach (var number in input)
            {
                var residual = number % 3;

                residual = Math.Abs(residual);

                switch (residual)
                {
                    case 0:
                        if (!result.ContainsKey(residual))
                        {
                            result[residual] = new List<int>();
                        }

                        result[residual].Add(number);
                        break;
                    case 1:
                        if (!result.ContainsKey(residual))
                        {
                            result[residual] = new List<int>();
                        }

                        result[residual].Add(number);
                        break;
                    case 2:
                        if (!result.ContainsKey(residual))
                        {
                            result[residual] = new List<int>();
                        }

                        result[residual].Add(number);
                        break;
                }
            }

            foreach (var pair in result.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value))
            {
                Console.WriteLine(string.Join(" ", pair.Value));
            }
        }
    }
}
