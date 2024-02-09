using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandRm : ICommand
    {
        public string Name => "rm";

        public string HelpText => "rm-[Name of a existing variable] -> Delete any existing variable by name";

        private Framework framework;
        public CommandRm(Framework inputFramework) 
        {
            framework = inputFramework;
        }

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            try
            {
                framework.DeleteVariable(Parameter);

                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Deleted {Parameter}");
                Console.ForegroundColor = currentColor;
            }
            catch (Exception ex)
            {
                throw new Exception("RM-Error: Couldnt delete variable: " + ex.Message);
            }
        }
    }
}
