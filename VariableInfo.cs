using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal abstract class VariableInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public VariableInfo(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public abstract string GetValueAsString();
    }
}
