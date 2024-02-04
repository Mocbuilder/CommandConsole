using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal interface ICommand
    {
        string Name { get; }
        string HelpText { get; }

        void Execute(string Parameter, string Parameter2, string Parameter3);
    }
}
