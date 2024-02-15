using CommandConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommandConsole
{
    internal class Framework
    {
        public List<ICommand> Commands = new List<ICommand>();
        public List<VariableInfo> Variables = new List<VariableInfo>();
        public Dictionary<string, ICommand> CommandAliases = new Dictionary<string, ICommand>();

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
            Commands.Add(new CommandPrint(this));
            Commands.Add(new CommandAdd(this));
            Commands.Add(new CommandGet(this));
            Commands.Add(new CommandCalc());
            Commands.Add(new CommandRm(this));
            Commands.Add(new CommandSetValue(this));
            Commands.Add(new CommandSetName(this));
            Commands.Add(new CommandProcess());
            Commands.Add(new CommandKill());
            Commands.Add(new CommandRead(this));
            Commands.Add(new CommandAlias(this));

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
            string[] inputArray = input.Split("-", 2);

            string cmd = inputArray[0];

            string parameters = (inputArray.Length > 0) ? inputArray[1] : "";

            return (cmd, parameters);
        }

        public List<VariableInfo> ParseParameters(ICommand command, string input)
        {
            string[] inputArray = input.Split("-");
            if(inputArray.Length != command.ParameterTypes.Count)
                throw new Exception($"Invalid count of parameters. Type 'help' for a list of commands.");

            List<VariableInfo> result = new List<VariableInfo>();
            int varPos = 0;
            foreach (var paramType in command.ParameterTypes)
            {
                string value = inputArray[varPos];
                VariableInfo varTypeInfo = Activator.CreateInstance(paramType) as VariableInfo;
                switch (varTypeInfo.Type)
                {
                    case VariableType.String:
                        result.Add(new StringInfo("", value));
                        break;
                    case VariableType.Int:
                        result.Add(new IntInfo("", Convert.ToInt32(value)));
                        break;
                    case VariableType.Bool:
                        result.Add(new BoolInfo("", Convert.ToBoolean(value)));
                        break;
                    default:
                        throw new Exception();
                }
                varPos++;
            }
            return result;
        }

        public void Execute(string userInput)
        {
            try
            {
                var (cmd, parameters) = ParseCommand(userInput);

                ICommand command = null;

                if (CommandAliases.ContainsKey(cmd))
                    command = CommandAliases[cmd];
                else
                   command = Commands.FirstOrDefault(x => x.Name == cmd);

                if (command == null)
                    throw new Exception($"Unknown command: {userInput}. Type 'help' for a list of commands.");

                List<VariableInfo> paramInfos = ParseParameters(command, parameters);
                // command.Execute(paramInfos);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }


        internal void AddVariable(VariableInfo variableInfo)
        {
            Variables.Add(variableInfo);
        }

        public VariableInfo GetVariable(string variableName)
        {
            try
            {
                VariableInfo variableGet = Variables.Find(variable => variable.Name == variableName);

                if (variableGet == null)
                {
                    throw new Exception("Variable not found");
                }

                return variableGet;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get variable");
            }
        }

        public void DeleteVariable(string variableName)
        {
            try
            {
                Variables.Remove(GetVariable(variableName));
            }
            catch(Exception ex)
            {
                throw new Exception("Couldnt delete variable");
            }
        }

        public void SetVariableValue(string variableName, string newValue)
        {
            VariableType variableType = GetVariable(variableName).Type;
            try
            {
                DeleteVariable(variableName);
                try
                {
                    switch (variableType)
                    {
                        case VariableType.String:
                            string newString = Convert.ToString(newValue);
                            AddVariable(new StringInfo(variableType, variableName, newString));
                            break;
                        case VariableType.Int:
                            int newInt = Convert.ToInt32(newValue);
                            AddVariable(new IntInfo(variableType, variableName, newInt));
                            break;
                        case VariableType.Bool:
                            bool newBool = Convert.ToBoolean(newValue);
                            AddVariable(new BoolInfo(variableType, variableName, newBool));
                            break;
                        default:
                            throw new Exception("Invalid type");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid type");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Couldnt set new variable value");
            }
        }

        public void SetVariableName(string oldName, string newName)
        {
            string variableType = GetVariable(oldName).Type;
            var variableValue = GetVariable(oldName).GetValueAsString();
            try
            {
                DeleteVariable(oldName);
                try
                {
                    switch (variableType)
                    {
                        case "string":
                            AddVariable(new StringInfo(variableType, newName, variableValue));
                            break;
                        case "int":
                            int newInt = Convert.ToInt32(variableValue);
                            AddVariable(new IntInfo(variableType, newName, newInt));
                            break;
                        case "bool":
                            bool newBool = Convert.ToBoolean(variableValue);
                            AddVariable(new BoolInfo(variableType, newName, newBool));
                            break;
                        default:
                            throw new Exception("Invalid name");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid name");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Couldnt set new variable name");
            }

        }
    }
}
