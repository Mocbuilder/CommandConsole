using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandPrint : ICommand
    {
        public string Name => "print";

        public string HelpText => "print-[Text to be printed or 'var']-[variable name] -> Prints specified text or, if that is var-[any existing variable], prints the value of the variable";
        private Framework framework;

        public CommandPrint(Framework framework)
        {
            this.framework = framework;
        }
        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {

            if(Parameter == "var")
            {
                VariablePrint(Parameter2);
                return;
            }
            NormalPrint(Parameter);
        }

        public void NormalPrint(string Parameter)
        {
            try
            {
                Console.WriteLine(Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception("Print-Error: Cant print input" + ex.Message);
            }
        }

        public void VariablePrint(string variableName)
        {
            try
            {
                VariableInfo variable = framework.GetVariable(variableName);

                if (variable != null)
                {
                    Console.WriteLine(variable.GetValueAsString());
                }
                else
                {
                    throw new Exception($"Print-Error: Variable {variableName} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Print-Error: Cant print variable {variableName}: {ex.Message}");
            }
        }

    }
}
