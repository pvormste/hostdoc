using System;

namespace HostDoc.Core.Services
{
    public class MacHostService : HostService
    {

        public override string GetHostFileLocation()
        {
            if (!(HostLocation is null)) 
                return HostLocation;

            var macdir = Environment.GetEnvironmentVariable("");
            return macdir;
        }
        
    }
}