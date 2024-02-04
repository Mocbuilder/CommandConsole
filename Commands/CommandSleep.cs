using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandSleep : ICommand
    {
        public string Name => "sleep";

        public string HelpText => "sleep-[any valid number] -> wait for specified time in seconds. Mainly used in scripting";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            if (int.TryParse(Parameter, out int inputTime))
            {
                Thread.Sleep(inputTime * 1000);
            }
            else
            {
                throw new Exception("Sleep-Error: Invalid number given as parameter");
            }
        }
    }
}
