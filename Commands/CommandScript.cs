using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandScript : ICommand
    {
        private Framework framework;

        public CommandScript(Framework framework)
        {
            this.framework = framework;
        }

        public string Name => "script";

        public string HelpText => "script-[Valid file path to a C# file]";

        public void Execute(string parameter)
        { 
            foreach(var line in File.ReadAllLines(parameter))
            {
                framework.Execute(line);
            } 
        }
    }
}
