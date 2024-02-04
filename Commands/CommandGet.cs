using System;

namespace CommandConsole.Commands
{
    internal class CommandGet : ICommand
    {
        public string Name => "get";

        public string HelpText => "get-[variable name] -> print any variable";
        private Framework framework;

        public CommandGet(Framework framework)
        {
            this.framework = framework;
        }

        public void Execute(string parameter, string parameter2, string parameter3)
        {
            VariableInfo variable = framework.GetVariable(parameter);

            if (variable != null)
            {
                Console.WriteLine($"{variable.Type} {variable.Name} = {variable.Value}");
                return;
            }
        }
    }
}
