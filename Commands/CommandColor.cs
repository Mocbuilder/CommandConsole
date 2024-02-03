using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandColor : ICommand
    {

        public CommandColor() { }

        public string Name => "setcolor";

        public string HelpText => "setcolor-[Any valid 8-Bit color] -> Sets the font color of the console";

        public void Execute(string parameter)
        {
            if (!Enum.TryParse(parameter, true, out ConsoleColor consoleColor))
                throw new Exception($"Invalid color: {parameter}. Using default color.");

            if (consoleColor == ConsoleColor.Red || consoleColor == ConsoleColor.DarkRed)
                throw new Exception("Can't use red as standard color, because it is reserved for important system infos.");

            Console.ForegroundColor = consoleColor;
            Console.WriteLine("Hello World!");
        }
    }
}
