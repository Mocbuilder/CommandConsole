using System;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommandConsole
{
    internal class Program
    {
        public static string userInput;

        
        public static List<ICommand> TLCommands = new List<ICommand>()
        {
            //new CommandHelp(TLCommands),
        };

        public static void Main(string[] args)
        {
            AddCommandsToList();
            while (true)
            {
                try
                {
                    userInput = Console.ReadLine();
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
                    SharedFuncs.Error(ex);
                }

            }
        }

        public static (string, string) ParseCommand(string input)
        {
            string[] inputArray = input.Split("-");
            string cmd = inputArray[0];
            string param = string.Join("-", inputArray.Skip(1));
            return (cmd, param);
        }

        internal static void AddCommandsToList()
        {
            TLCommands.Add(new CommandHelp(TLCommands));
            TLCommands.Add(new CommandColor());
        }
    }
}