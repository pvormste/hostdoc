using System;
using HostDoc.ConsoleApp.Commands;
using Microsoft.Extensions.CommandLineUtils;


namespace HostDoc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand command = null;
            
            CommandLineApplication commandLineApplication = new CommandLineApplication();
            
            // Show Command
            commandLineApplication.Command("show", (app) =>
            {
                command = new ShowCommand();
                command.Execute(app);
            });
        }
    }
}
