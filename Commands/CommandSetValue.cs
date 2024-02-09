using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandSetValue : ICommand
    {
        public string Name => "setvalue";

        public string HelpText => "setvalue-[Name of existing variable]-[New value] -> Set a new value to an already existing variable. New value must be of the same type as the old value";

        private Framework framework;

        public CommandSetValue(Framework inputFramework)
        {
            framework = inputFramework;
        }
        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            var oldValue = framework.GetVariable(Parameter).GetValueAsString();
            framework.SetVariableValue(Parameter, Parameter2);
            Console.WriteLine($"Changed {Parameter} = {oldValue} to {Parameter} = {Parameter2}");
        }
    }
}
