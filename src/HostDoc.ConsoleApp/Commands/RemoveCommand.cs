using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Remove an entry in the host file"), HelpOption]
    public class RemoveCommand
    {
        [Option(Description = "IP Address of the entry to be removed (optional)", LongName = "ip")]
        public string IpAddress { get; set; }

        [Option(Description = "Hostname of the entry to be removed (optional)", ShortName = "host")]
        public string Hostname { get; set; }

        [Option("--all", Description = "Remove all occurences (optional)")]
        public bool All { get; set; }
        
        void OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("Remove command");
        }
    }
}