using CommandConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class Framework
    {

        public static List<ICommand> TLCommands = new List<ICommand>();
        public Framework()
        {
            AddCommandsToList();   
        }
        internal void AddCommandsToList()
        {
            TLCommands.Add(new CommandHelp(TLCommands));
            TLCommands.Add(new CommandColor());
            TLCommands.Add(new CommandJoke());
            TLCommands.Add(new CommandIP());
            TLCommands.Add(new CommandPing());
            TLCommands.Add(new CommandSystem());
            TLCommands.Add(new CommandHacker());
            TLCommands.Add(new CommandClear());
            TLCommands.Add(new CommandExit());
            TLCommands.Add(new CommandScript(this));
            TLCommands.Add(new CommandSleep());
            TLCommands.Add(new CommandPrint());
        }

        public void HandleError(Exception e)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + e.Message);
            Console.ForegroundColor = currentColor;
        }

        public (string, string) ParseCommand(string input)
        {
            string[] inputArray = input.Split("-");
            string cmd = inputArray[0];
            string param = string.Join("-", inputArray.Skip(1));
            return (cmd, param);
        }
        public void Execute(string userInput)
        {
            try
            {
                var (cmd, param) = ParseCommand(userInput);
                var command = TLCommands.FirstOrDefault(x => x.Name == cmd);
                if (command != null)
                {
                    command.Execute(param);
                }
                else
                {
                    throw new Exception($"Unknown command: {userInput}. Type 'help' for a list of commands.");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
