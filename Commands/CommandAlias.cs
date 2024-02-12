using System;
using System.Linq;

namespace CommandConsole.Commands
{
    internal class CommandAlias : ICommand
    {
        public string Name => "alias";

        public string HelpText => "alias-[Command you want to alias]-[New command] -> Set the keyword for any command";

        private Framework framework;

        public CommandAlias(Framework inputFramework)
        {
            framework = inputFramework;
        }

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            var commandToAlias = framework.Commands.FirstOrDefault(x => x.Name == Parameter);
            if (commandToAlias != null)
            {
                framework.CommandAliases[Parameter2] = commandToAlias;
                Console.WriteLine($"Alias '{Parameter2}' for command '{Parameter}' set successfully.");
            }
            else
            {
                throw new Exception($"Unknown command to be aliased: {Parameter}. Type 'help' for a list of commands.");

            }
        }
    }
}
