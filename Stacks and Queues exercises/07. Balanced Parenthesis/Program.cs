using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>();

            foreach (var character in input)
            {
                var stringifiedChar = character.ToString();
                var closingChars = new string[] {")", "]", "}"};
                if (!closingChars.Contains(stringifiedChar))
                {
                    stack.Push(stringifiedChar);
                }
                else
                {

                    if (stack.Count > 0 && CheckCharacters.Check(stack.Peek(), stringifiedChar))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                
            }

            Console.WriteLine("YES");
        }
    }

    public class CheckCharacters
    {
        public static bool Check(string first, string second)
        {
            bool result = false;

            if (first == "(" && second == ")")
            {
                result = true;
            } else if (first == "[" && second == "]")
            {
                result = true;
            } else if (first == "{" && second == "}")
            {
                result = true;
            }

            return result;
        }
    }
}
