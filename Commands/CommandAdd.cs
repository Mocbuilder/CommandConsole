using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandAdd : ICommand
    {
        public string Name => "add";

        public string HelpText => "add-[type]-[name]-[value] -> Add a variable as 'string' or 'int'";
        private Framework framework;
        public CommandAdd(Framework frm)
        {
            this.framework = frm;
        }
        public void Execute(string type, string name, string value)
        {
            bool variableExists = false;
            VariableInfo variable = null;
            try
            {
                variable = framework.GetVariable(name);
                variableExists = true;
            }
            catch
            {
                //Varibale doesnt exist, so carry on
            }

            if (variableExists)
            {
                throw new Exception("Variable already exists");
            }

            try
            {
                switch (type)
                {
                    case "string":
                        framework.AddVariable(new StringInfo(type, name, value));
                        break;
                    case "int":
                        int newInt = Convert.ToInt32(value);
                        framework.AddVariable(new IntInfo(type, name, newInt));
                        break;
                    case "bool":
                        bool newBool = Convert.ToBoolean(value);
                        framework.AddVariable(new BoolInfo(type, name, newBool));
                        break;
                    default:
                        throw new Exception("Add-Error: Invalid type");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid type of variable");
            }
        }

    }
}
