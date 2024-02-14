using CommandConsole;

internal class CommandScript : ICommand
{
    private Framework framework;

    public CommandScript(Framework framework)
    {
        this.framework = framework;
    }

    public string Name => "script";

    public string HelpText => "script-[Valid file path to a txt file]";

    public void Execute(string Parameter, string Parameter2, string Parameter3)
    {
        foreach (var line in File.ReadAllLines(Parameter))
        {
            string ToExecute = CheckForComment(line);
            if (ToExecute != null)
            {
                framework.Execute(ToExecute);
            }
        }
    }

    public string CheckForComment(string line)
    {
        string toCheck = line.TrimStart();

        if (string.IsNullOrWhiteSpace(toCheck))
            return null;

        if (!toCheck.StartsWith("//"))
            return toCheck;

        return null;
    }
}
