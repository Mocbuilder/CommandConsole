using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandPrint : ICommand
    {
        public string Name => "print";

        public string HelpText => "print-[Text to be printed] -> Prints specified text";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            try
            {
                Console.WriteLine(Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Print-Error: Cant print input" + ex.Message);
            }
        }
    }
}
