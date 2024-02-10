using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandKill : ICommand
    {
        public string Name => "kill";

        public string HelpText => "kill-[Name of any running process] -> Terminates the specified process. Could need Admin priviliges to execute properly";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Process[] processCollection = Process.GetProcesses();

            Process foundProcess = Array.Find(processCollection, p => p.ProcessName == Parameter);

            if (foundProcess != null)
            {
                foundProcess.Kill();
                Console.WriteLine("Terminated process: " + foundProcess.ProcessName);
            }
            else
            {
                throw new Exception("Process not found");
            }

        }
    }
}
