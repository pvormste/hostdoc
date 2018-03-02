using HostDoc.ConsoleApp.Commands;
using HostDoc.Core;
using McMaster.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp
{
    [Command(ThrowOnUnexpectedArgument = false), HelpOption]
    [Subcommand("ls", typeof(ListCommand))]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
        
        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.Error.WriteLine("You must provide valid arguments");
            app.ShowHelp();
            return (int) ExitCode.InvalidArguments;
        }
    }
}
