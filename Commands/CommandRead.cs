using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class CommandRead : ICommand
    {
        public string Name => "read";

        public string HelpText => "read-[Type of new variable]-[Name of new variable]-[Message to be printed before the input] -> Creates a new variable and puts the next userinput as value, while printing a message to the user";

        private Framework asdframework;

        public CommandRead(Framework inputFramework)
        {
            inputFramework = asdframework;
        }
    
        public void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            Console.WriteLine(Parameter3);
            string userInput = Console.ReadLine();
            switch (Parameter)
            {
                case "string":
                    asdframework.AddVariable(new StringInfo(Parameter, Parameter2, userInput));
                    break;
                case "int":
                    int intValue = Convert.ToInt32(userInput);
                    asdframework.AddVariable(new IntInfo(Parameter, Parameter2, intValue));
                    break;
                case "bool":
                    bool boolValue = Convert.ToBoolean(userInput);
                    asdframework.AddVariable(new BoolInfo(Parameter, Parameter2, boolValue));
                    break;
                default:
                    throw new Exception("Couldnt add new variable");
            }
        }
    }
}
