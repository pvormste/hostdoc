using System;
using Microsoft.Win32;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : AbstractHostService
    {
        protected override string GetHostFileLocation()
        {
            if (HostLocation != null) 
                return HostLocation;
            
            // Lookup env
            HostLocation = Environment.GetEnvironmentVariable("HOSTFILE_LOCATION");
            if (HostLocation != null)
                return HostLocation;
            
            // Lookup registry
            HostLocation = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "DataBasePath", null) as string;
            if (HostLocation != null)
            {
                HostLocation = $"{HostLocation}\\hosts";
                return HostLocation;
            }
            
            // ... old school!
            var windir = Environment.GetEnvironmentVariable("windir");
            HostLocation = windir + @"\System32\drivers\etc\hosts";
            return HostLocation;
        }
    }
}