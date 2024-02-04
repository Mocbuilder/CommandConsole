using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandHelp : ICommand
    {
        public string Name => "help";

        public string HelpText => "help -> Lists all available commands";

        private List<ICommand> allCommands;

        public CommandHelp(List<ICommand> allCommands)
        {
            this.allCommands = allCommands;
        }

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Console.WriteLine("All available commands are:");

            foreach (var command in allCommands)
                Console.WriteLine($"- {command.HelpText}");
        }
    }
}
