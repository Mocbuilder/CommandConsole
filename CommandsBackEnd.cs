using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    public class CommandsBackEnd
    {
        public static void PrintHelp()
        {

        }

        public static void SetConsColor()
        {
            string[] parts = Program.userInput.Split('-', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2 || parts.Length > 2)
                throw new Exception("Invalid input format for 'setcolor' command. Use 'setcolor-variable'.");

            string variable = parts[1].ToLower();

            if (!Enum.TryParse(variable, true, out ConsoleColor consoleColor))
                throw new Exception($"Invalid color: {variable}. Using default color.");

            if (consoleColor == ConsoleColor.Red || consoleColor == ConsoleColor.DarkRed)
                throw new Exception("Can't use red as standard color, because it is reserved for important system infos.");
           
            Console.ForegroundColor = consoleColor;
            Console.WriteLine("Hello World!");
        }
    }
}
