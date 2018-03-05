using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Remove an entry in the host file"), HelpOption]
    public class RemoveCommand
    {

        void OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("Remove command");
        }
    }
}