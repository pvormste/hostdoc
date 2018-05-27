using System;
using System.Runtime.InteropServices;
using HostDoc.Core.Services;

namespace HostDoc.Core
{
    public static class Utils
    {
        public static AbstractHostService GetHostService()
        {
            AbstractHostService hostService = null;
            
            // Get Host Service for this OS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                hostService = new WindowsHostService();
            }
            
            if (hostService is null)
            {
                Console.Error.WriteLine("OS is not supported."); // TODO: Logger
                Environment.Exit((int) ExitCode.InvalidOperatingSystem);
            }

            return hostService;
        }
    }
}