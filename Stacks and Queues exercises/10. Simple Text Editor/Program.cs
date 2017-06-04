using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var stackCommands = new Stack<Dictionary<int, string>>();

            var text = string.Empty;

            for (int i = 0; i < count; i++)
            {
                var command = Console.ReadLine().Split();

                var commandNumber = int.Parse(command[0]);

                var commandString = string.Empty;

                if (commandNumber != 4)
                {
                    commandString = command[1];
                }

                switch (commandNumber)
                {
                case 1:
                    text += commandString;
                    commandString = commandString.Length.ToString();
                    var dictionary = new Dictionary<int, string>()
                    {
                        {commandNumber, commandString}
                    };
                        
                    stackCommands.Push(dictionary);
                    stackCommands.TrimExcess();
                    break;
                case 2:

                    var index = int.Parse(commandString);
                    commandString = text.Substring(text.Length - index, index);
                    text = text.Remove(text.Length - index, index);

                    dictionary = new Dictionary<int, string>()
                    {
                        {commandNumber, commandString}
                    };

                    stackCommands.Push(dictionary);
                    stackCommands.TrimExcess();
                    break;
                case 3:
                    index = int.Parse(commandString);
                    Console.WriteLine(text[index-1]);
                    break;
                case 4:

                    var commandToUndo = stackCommands.Pop();

                    foreach (var pair in commandToUndo)
                    {
                        commandNumber = pair.Key;
                        commandString = pair.Value;
                    }

                    switch (commandNumber)
                    {
                            case 1:
                                index = int.Parse(commandString);
                                text = text.Remove(text.Length - index, index);

                                break;
                            case 2:
                                text += commandString;
                                break;
                    }
                    break;
                }
            }
        }
    }
}
