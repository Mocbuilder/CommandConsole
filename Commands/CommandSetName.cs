using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandSetName : ICommand
    {
        public string Name => "setname";

        public string HelpText => "setname-[Name of a existing variable]-[New name of that variable] -> Set the name of any existing variable to a new name";
        private Framework framework;

        public CommandSetName(Framework inputFramework)
        {
            framework = inputFramework;
        }
        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            framework.SetVariableName(Parameter, Parameter2);
            Console.WriteLine($"Variable {Parameter} changed to {Parameter2}");
        }
    }
}
