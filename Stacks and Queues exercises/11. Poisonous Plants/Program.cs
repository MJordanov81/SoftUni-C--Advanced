using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var pesticide = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var temp = new Queue<int>();
            var day = 0;

            while (true)
            {
                temp.Enqueue(pesticide[0]);
                for (int i = 1; i < pesticide.Length; i++)
                {
                    
                    if (pesticide[i] <= pesticide[i - 1])
                    {
                        temp.Enqueue(pesticide[i]);
                    }
                }

                if (temp.Count == pesticide.Length)
                {
                    break;
                }

                pesticide = new int[temp.Count];

                for (int i = 0; i < pesticide.Length; i++)
                {
                    pesticide[i] = temp.Dequeue();
                }
                temp.Clear();
                day++;
            }

            Console.WriteLine(day);
        }
    }
}
