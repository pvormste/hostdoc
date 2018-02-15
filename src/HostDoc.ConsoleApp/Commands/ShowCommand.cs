using System;
using System.Runtime.InteropServices;
using HostDoc.Core.Services;
using Microsoft.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    public class ShowCommand : ICommand
    {
        public void Execute(CommandLineApplication app, IHostService hostService)
        {      
            Console.WriteLine("Show Command!");
            hostService.ReadHostEntries();
        }
    }
}