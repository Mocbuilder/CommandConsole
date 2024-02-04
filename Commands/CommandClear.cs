using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandClear : ICommand
    {
        public string Name => "clear";

        public string HelpText => "clear -> Clears the console";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Console.Clear();
        }
    }
}
