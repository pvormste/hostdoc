using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Replace an entry in the host file"), HelpOption]
    public class ReplaceCommand
    {
        void OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("Replace Command");
        }
    }
}