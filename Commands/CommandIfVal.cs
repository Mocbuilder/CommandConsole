using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandIfVal : ICommand
    {
        public string Name => "ifval";

        public string HelpText => "if-[any existing variable]-[desired value]-[name of new bool variable that will hold the result] -> Checks if a variable has a specific value";
        private CommandConsole.Framework framework;

        public CommandIfVal(CommandConsole.Framework inputFramework)
        {
            framework = inputFramework;
        }

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
             if(framework.GetVariable(Parameter).Value == Parameter2)
             {
                VariableInfo newVariable = new VariableInfo("bool", Parameter3, "true");
                framework.AddVariable(newVariable);
                Console.WriteLine($"The condition if true (Result: {Parameter3})");
            }
            else
            {
                VariableInfo newVariable = new VariableInfo("bool", Parameter3, "false");
                framework.AddVariable(newVariable);
                Console.WriteLine($"The condition if false (Result: {Parameter3})");
            }  
        }
    }
}
