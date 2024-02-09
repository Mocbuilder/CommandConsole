using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class IntInfo : VariableInfo
    {
        public int Value { get; set; }

        public IntInfo(string typeOf, string variableName, int value) : base(typeOf, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value.ToString();
        }
    }
}
