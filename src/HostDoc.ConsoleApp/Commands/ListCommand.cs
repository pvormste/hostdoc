using System.Collections.Generic;
using ConsoleTables;
using HostDoc.Core;
using HostDoc.Core.Definitions;
using HostDoc.Core.Types;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "List all entries in the host file"), HelpOption]
    public class ListCommand
    {
        [Option(Description = "Filter by ip (optional)", ShortName = "i", LongName = "ip")]
        public string IpAddress { get; set; }
        
        [Option(Description = "Filter by hostname (optional)", ShortName = "host", LongName = "hostname")]
        public string Hostname { get; set; }
        
        public void OnExecute(CommandLineApplication app, IConsole console)
        {
            var hostService = Utils.GetHostService();
            List<HostEntry> hostEntries = null;
            
            // Check if filter was applied
            if (IpAddress != null)
            {
                hostEntries = hostService.FilterHostEntries(EntryType.IpAdress, IpAddress);
            }
            else if (Hostname != null)
            {
                hostEntries = hostService.FilterHostEntries(EntryType.Hostname, Hostname);
            }
            else
            {
                hostEntries = hostService.ReadHostEntries();
            }
            
            ConsoleTable.From(hostEntries).Write(Format.MarkDown);
        }
    }
}