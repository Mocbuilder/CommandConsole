using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class BoolInfo : VariableInfo
    {
        public bool Value { get; set; }

        public BoolInfo(string typeOf, string variableName, bool value) : base(typeOf, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value.ToString();
        }
    }
}
