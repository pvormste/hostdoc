using Microsoft.Extensions.CommandLineUtils;

namespace HostDoc.ConsoleApp.Commands
{
    public interface ICommand
    {
        void Execute(CommandLineApplication app);
    }
}