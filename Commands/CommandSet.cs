using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandSet : ICommand
    {
        public string Name => "set";

        public string HelpText => "set-[type]-[name]-[value] -> Set a variable as 'string' or 'int'";
        private Framework framework;
        public CommandSet(Framework frm)
        {
            this.framework = frm;
        }
        public void Execute(string type, string name, string value)
        {
            framework.AddVariable(new VariableInfo(type, name, value));
        }
    }
}
