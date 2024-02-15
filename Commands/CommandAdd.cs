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

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo), typeof(StringInfo), typeof(StringInfo) };

        private Framework framework;
        public CommandAdd(Framework frm)
        {
            this.framework = frm;
        }
        public void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;
            StringInfo param2 = inputParams[1] as StringInfo;

            bool variableExists = false;
            VariableInfo variable = null;
            try
            {
                variable = framework.GetVariable(param.Value);
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
                switch (param2.Value)
                {
                    case "string":
                        StringInfo param3String = inputParams[2] as StringInfo;
                        framework.AddVariable(new StringInfo(param.Value, param3String.Value));
                        break;
                    case "int":
                        IntInfo param3Int = inputParams[2] as IntInfo;
                        int newInt = Convert.ToInt32(param3Int.Value);
                        framework.AddVariable(new IntInfo(param.Value, newInt));
                        break;
                    case "bool":
                        BoolInfo param3Bool = inputParams[2] as BoolInfo;
                        bool newBool = Convert.ToBoolean(param3Bool.Value);
                        framework.AddVariable(new BoolInfo(param.Value, newBool));
                        break;
                    default:
                        throw new Exception("Invalid type");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid type of variable");
            }
        }

    }
}
