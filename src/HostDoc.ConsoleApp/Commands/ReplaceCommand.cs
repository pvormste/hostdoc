using System;
using HostDoc.Core;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    [Command(Description = "Replace an entry in the host file"), HelpOption]
    public class ReplaceCommand
    {
        [Option(Description = "Old and new ip address of the entry to be replaced (format: OLD.IP<NEW.IP or NEW.IP>OLD.IP, optional, if hostname given)", ShortName = "i", LongName = "ip")]
        public string IpAddress { get; set; }

        [Option(Description = "Old and new hostname of the entry to be replaced (format: OLD.HOSTNAME<NEW.HOSTNAME or NEW.HOSTNAME>OLD.HOSTNAME, optional, if ip given)", ShortName = "host", LongName = "hostname")]
        public string Hostname { get; set; }

        [Option("--all", Description = "Replace all occurences (optional)")]
        public bool All { get; set; }
        
        void OnExecute(CommandLineApplication app, IConsole console)
        {
            if (IpAddress == null && Hostname == null)
            {
                Console.Error.WriteLine("Error: Please provide the ip address and/or the hostname of the hostname to be replaced");
                Environment.Exit((int) ExitCode.InvalidArguments);
            }
            
            if (IpAddress != null && !IpAddress.Contains("<") && !IpAddress.Contains(">"))
            {
                Console.Error.WriteLine("Error: Wrong format. Please use OLD.IP<NEW.IP or NEW.IP>OLD.IP");
                Environment.Exit((int) ExitCode.InvalidArguments);
            }

            if (Hostname != null && !Hostname.Contains("<") && !Hostname.Contains(">"))
            {
                Console.Error.WriteLine("Error: Wrong format. Please use OLD.HOSTNAME<NEW.HOSTNAME or NEW.HOSTNAME>OLD.HOSTNAME");
                Environment.Exit((int) ExitCode.InvalidArguments);
            }
            
            console.WriteLine("Replace Command");
        }
    }
}