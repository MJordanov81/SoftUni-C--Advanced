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
            var stackCommands = new Stack<string>();

            StringBuilder stringbuilder = new StringBuilder("");

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
                    stringbuilder.Append(commandString);
                    var undoCommand = commandNumber + " " + commandString.Length;
                    stackCommands.Push(undoCommand);
                    break;

                case 2:
                    var index = int.Parse(commandString);
                    string temp = stringbuilder.ToString().Substring(stringbuilder.Length - index, index);
                    stringbuilder.Remove(stringbuilder.Length - index, index);
                    undoCommand = commandNumber + " " + temp;
                    stackCommands.Push(undoCommand);
                    break;

                case 3:
                    index = int.Parse(commandString);
                    Console.WriteLine(stringbuilder[index - 1]);
                    break;

                case 4:
                    var commandToUndo = stackCommands.Pop().Split().ToList();
                    commandNumber = int.Parse(commandToUndo[0]);
                    commandString = commandToUndo[1];

                    switch (commandNumber)
                    {
                        case 1:
                            index = int.Parse(commandString);
                            stringbuilder.Remove(stringbuilder.Length - index, index);
                            break;

                        case 2:
                            stringbuilder.Append(commandString);
                            break;
                    }
                    break;
                }
            }
        }
    }
}
