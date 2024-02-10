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
            Variables.Add(variableInfo);
        }

        public VariableInfo GetVariable(string variableName)
        {
            try
            {
                VariableInfo variableGet = Variables.Find(variable => variable.Name == variableName);

                if (variableGet == null)
                {
                    throw new Exception("Get-Error: Variable not found");
                }

                return variableGet;
            }
            catch (Exception ex)
            {
                throw new Exception("Get-Error: Could not get variable: " + ex.Message);
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
                throw new Exception("RM-Error: Couldnt delete variable: " + ex.Message);
            }
        }

        public void SetVariableValue(string variableName, string newValue)
        {
            string variableType = GetVariable(variableName).Type;
            try
            {
                DeleteVariable(variableName);
                try
                {
                    switch (variableType)
                    {
                        case "string":
                            string newString = Convert.ToString(newValue);
                            AddVariable(new StringInfo(variableType, variableName, newString));
                            break;
                        case "int":
                            int newInt = Convert.ToInt32(newValue);
                            AddVariable(new IntInfo(variableType, variableName, newInt));
                            break;
                        case "bool":
                            bool newBool = Convert.ToBoolean(newValue);
                            AddVariable(new BoolInfo(variableType, variableName, newBool));
                            break;
                        default:
                            throw new Exception("Variable-Error: Invalid type");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Variable-Error: Invalid type: " + ex.Message);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Variable-Error: Couldnt set new variable value: " + ex.Message);
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
                            throw new Exception("Variable-Error: Invalid name");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Variable-Error: Invalid name: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Variable-Error: Couldnt set new variable name: " + ex.Message);
            }

        }
    }
}
