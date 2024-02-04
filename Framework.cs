using CommandConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class Framework
    {
        public List<ICommand> Commands = new List<ICommand>();
        public List<VariableInfo> Variables = new List<VariableInfo>();
        public Framework()
        {
            AddCommandsToList();   
        }
        internal void AddCommandsToList()
        {
            Commands.Add(new CommandHelp(Commands));
            Commands.Add(new CommandColor());
            Commands.Add(new CommandJoke());
            Commands.Add(new CommandIP());
            Commands.Add(new CommandPing());
            Commands.Add(new CommandSystem());
            Commands.Add(new CommandHacker());
            Commands.Add(new CommandClear());
            Commands.Add(new CommandExit());
            Commands.Add(new CommandScript(this));
            Commands.Add(new CommandSleep());
            Commands.Add(new CommandPrint());
            Commands.Add(new CommandSet(this));
        }

        public void HandleError(Exception e)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + e.Message);
            Console.ForegroundColor = currentColor;
        }

        public (string, string, string, string) ParseCommand(string input)
        {
            string[] inputArray = input.Split("-");

            string cmd = inputArray[0];

            string param = (inputArray.Length > 1) ? inputArray[1] : "";
            string param2 = (inputArray.Length > 2) ? inputArray[2] : "";
            string param3 = (inputArray.Length > 3) ? inputArray[3] : "";

            return (cmd, param, param2, param3);
        }

        public void Execute(string userInput)
        {
            try
            {
                var (cmd, param, param2, param3) = ParseCommand(userInput);
                var command = Commands.FirstOrDefault(x => x.Name == cmd);
                if (command != null)
                {
                    command.Execute(param, param2, param3);
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

        internal void AddVariable(VariableInfo variableInfo)
        {
            switch (variableInfo.Type)
            {
                case "int":
                case "string":
                    break;
                default:
                    throw new Exception("Variable-Error: Invalid type");
            }
            Variables.Add(variableInfo);
        }
        public VariableInfo GetVariable(string variableName)
        {
            return Variables.Find(variable => variable.Name == variableName);
        }

    }
}
