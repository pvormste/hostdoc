using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Replace an entry in the host file"), HelpOption]
    public class ReplaceCommand
    {
        [Option(Description = "IP Address of the entry to be replaced (only allowed, if hostname not given)", LongName = "ip")]
        public string IpAddress { get; set; }

        [Option(Description = "Hostname of the entry to be replaced (only allowed, if ip not given)", ShortName = "host")]
        public string Hostname { get; set; }

        [Option(Description = "New value of the entry (ip or hostname)", LongName = "new")]
        [Required]
        public string NewValue { get; set; }

        [Option("--all", Description = "Replace all occurences (optional)")]
        public bool All { get; set; }
        
        void OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("Replace Command");
        }
    }
}