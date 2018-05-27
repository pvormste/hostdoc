using System;
using System.Collections.Generic;
using System.IO;
using HostDoc.Core.Definitions;
using HostDoc.Core.Extensions;
using HostDoc.Core.Types;
using Microsoft.Win32;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : IHostService
    {
        string hostLocation = null;

        public string GetHostFileLocation()
        {
            if (hostLocation != null) 
                return hostLocation;
            
            // Lookup env
            hostLocation = Environment.GetEnvironmentVariable("HOSTFILE_LOCATION");
            if (hostLocation != null)
                return hostLocation;
            
            // Lookup registry
            hostLocation = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "DataBasePath", null) as string;
            if (hostLocation != null)
            {
                hostLocation = $"{hostLocation}\\hosts";
                return hostLocation;
            }
            
            // ... old school!
            var windir = Environment.GetEnvironmentVariable("windir");
            hostLocation = windir + @"\System32\drivers\etc\hosts";
            return hostLocation;
        }

        public List<HostEntry> ReadHostEntries(string ipFilter = null, string hostnameFilter = null)
        {
            List<HostEntry> hostEntries = new List<HostEntry>();

            try
            {
                using (StreamReader sr = new StreamReader(GetHostFileLocation()))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        // Check if line is relevant
                        line = line.TrimAll();
                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            continue;
                    
                        // Extract the entries
                        string[] lineParts = line.Split(' ');
                        string other = lineParts.JoinFrom(2, " ");
                        
                        // Check for filter
                        var isIpFilterSet = ipFilter != null;
                        var isHostNameFilterSet = hostnameFilter != null;

                        
                        if ((ipFilter == null && hostnameFilter == null) ||
                            (isIpFilterSet && ipFilter.Equals(lineParts[0])) ||
                            (isHostNameFilterSet && hostnameFilter.Equals(lineParts[1])))
                        {
                            var hostEntry = new HostEntry(lineParts[0], lineParts[1], other);
                            hostEntries.Add(hostEntry);
                        }  
                        
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is DirectoryNotFoundException directoryNotFoundException)
                    Console.Error.WriteLine($"Error: host file could not be found. ({hostLocation})");
                else 
                    Console.Error.WriteLine(exception.Message);
                
                // Print Stack Trace if Debug Build
                #if DEBUG
                    Console.Error.Write(exception.StackTrace);
                #endif
            }

            return hostEntries;
        }

        public List<HostEntry> FilterHostEntries(EntryType type, string filterValue, List<HostEntry> hostEntries = null)
        {
            List<HostEntry> entries;
            
            switch (type)
            {
                case EntryType.IpAdress:
                    entries = ReadHostEntries(filterValue);
                    break;
                case EntryType.Hostname:
                    entries = ReadHostEntries(null, filterValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return entries;
        }

        public bool AddHostEntry(HostEntry hostEntry)
        {
            throw new NotImplementedException();
        }

        public bool AddMultipleHostEntries(List<HostEntry> hostEntries)
        {
            throw new NotImplementedException();
        }

        public bool ReplaceHostEntry(EntryType type, string oldValue, string newValue)
        {
            throw new NotImplementedException();
        }

        public bool RemoveHostEntry(HostEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}