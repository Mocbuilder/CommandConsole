using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandExit : ICommand
    {
        public string Name => "exit";

        public string HelpText => "exit -> Quit the application";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Environment.Exit(0);
        }
    }
}
