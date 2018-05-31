﻿using System;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : HostService
    {

        public override string GetHostFileLocation()
        {
            if (!(HostLocation is null))
                return base.HostLocation;

            var windir = Environment.GetEnvironmentVariable("windir");
            HostLocation = windir + @"\System32\drivers\etc\hosts";
            return HostLocation;
        }
        
    }
}