using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class StringInfo : VariableInfo
    {
        public string Value { get; set; }

        public StringInfo(string typeOf, string variableName, string value) : base(typeOf, variableName)
        {
            Value = value;
        }

        public override string GetValueAsString()
        {
            return Value;
        }
    }
}
