using System;
using System.Runtime.InteropServices;
using HostDoc.ConsoleApp.Commands;
using HostDoc.Core.Services;
using Microsoft.Extensions.CommandLineUtils;


namespace HostDoc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand command = null;
            IHostService hostService = null;
            
            // Get Host Service for this OS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                hostService = new WindowsHostService();
            }

            if (hostService is null)
            {
                Console.Error.WriteLine("OS is not supported.");
                Environment.Exit(1);
            }

            // Init Command Line App
            CommandLineApplication commandLineApplication = new CommandLineApplication();
            
            // Show Command
            commandLineApplication.Command("show", (app) =>
            {
                command = new ShowCommand();
                command.Execute(app, hostService);
            });
        }
    }
}
