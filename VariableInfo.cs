using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class VariableInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public VariableInfo(string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
