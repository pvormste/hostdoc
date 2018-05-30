using System;
using System.ComponentModel.DataAnnotations;
using HostDoc.Core;
using HostDoc.Core.Definitions;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Add a new entry to host file"), HelpOption]
    public class AddCommand
    {
        [Option(Description = "IP Address of the new entry (optional, default: 127.0.0.1)", ShortName = "i", LongName = "ip")]
        public string IpAddress { get; set; }
        
        [Option(Description = "Hostname of the new entry", ShortName = "host")]
        [Required]
        public string Hostname { get; set; }
        
        [Option(Description = "Comment for the new entry (optional)")]
        public string Comment { get; set; }
        
        public void OnExecute(CommandLineApplication app, IConsole console)
        {
            if (string.IsNullOrWhiteSpace(IpAddress))
                IpAddress = "127.0.0.1";
          
            var newEntry = new HostEntry(IpAddress, Hostname, Comment);
            var hostService = Utils.GetHostService();
            var success = hostService.AddHostEntry(newEntry);

            if (!success)
            {
                Console.WriteLine("The new host entry was NOT added to host file.");
            }
            else
            {
                Console.WriteLine("The new host entry was SUCCESSFULLY added!");
            }
        }
    }
}