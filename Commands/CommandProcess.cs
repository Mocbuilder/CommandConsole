using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandProcess : ICommand
    {
        public string Name => "prcs";

        public string HelpText => "prcs -> List all currently running processes";

        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                if (!IsSystemProcess(p.ProcessName))
                {
                    Console.WriteLine("Name: " + p.ProcessName + "   ID: " + p.Id);
                }
            }
        }

        private bool IsSystemProcess(string processName)
        {
            string[] systemProcessNames = { "svchost", "conhost", "RuntimeBroker", "dllhost", "ntoskrnl", "explorer"};

            return Array.Exists(systemProcessNames, name => name.Equals(processName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
