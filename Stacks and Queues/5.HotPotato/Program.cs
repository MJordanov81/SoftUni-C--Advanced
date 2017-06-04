using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var number = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(input);
            var cycle = 1;

            while(queue.Count > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (!CheckPrime.IsPrime(cycle))
                {
                    Console.WriteLine("Removed " + queue.Dequeue());
                }
                else
                {
                    Console.WriteLine("Prime " + queue.Peek());
                }


                cycle++;
            }

            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }

    public class CheckPrime
    {
        public static bool IsPrime(int number)
        {
            // Test whether the parameter is a prime number.
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return number != 1;
        }
    }
}
