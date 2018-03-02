using HostDoc.Core;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "List all entries in the host file"), HelpOption]
    public class ListCommand
    {
        public void OnExecute(CommandLineApplication app, IConsole console)
        {
            var hostService = Utils.GetHostService();
            
            console.WriteLine("List Command!");
            hostService.ReadHostEntries();
        }
    }
}