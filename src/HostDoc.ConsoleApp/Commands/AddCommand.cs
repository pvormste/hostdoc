using System.ComponentModel.DataAnnotations;
using HostDoc.Core;
using HostDoc.Core.Definitions;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Add a new entry to host file"), HelpOption]
    public class AddCommand
    {
        [Option(Description = "IP Address of the new entry", ShortName = "i", LongName = "ip")]
        [Required]
        public string IpAddress { get; set; }
        
        [Option(Description = "Hostname of the new entry", ShortName = "host")]
        [Required]
        public string Hostname { get; set; }
        
        [Option(Description = "Comment for the new entry")]
        public string Comment { get; set; }
        
        public void OnExecute(CommandLineApplication app, IConsole console)
        {
            var newEntry = new HostEntry(IpAddress, Hostname, Comment);
            var hostService = Utils.GetHostService();
            hostService.AddHostEntry(newEntry);
        }
    }
}