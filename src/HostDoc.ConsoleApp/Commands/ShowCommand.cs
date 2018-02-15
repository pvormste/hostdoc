using System;
using Microsoft.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    public class ShowCommand : ICommand
    {
        public void Execute(CommandLineApplication app)
        {
            Console.WriteLine("Show Command!");
        }
    }
}