using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HostDoc.Core.Definitions;
using HostDoc.Core.Extensions;
using HostDoc.Core.Types;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : IHostService
    {
        const string HostLocation = @"C:\Windows\System32\drivers\etc\hosts";

        public string GetHostFileLocation()
        {
            return HostLocation;
        }

        public List<HostEntry> ReadHostEntries()
        {
            List<HostEntry> hostEntries = new List<HostEntry>();
            
            using (StreamReader sr = new StreamReader(HostLocation))
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
                    
                    var hostEntry = new HostEntry(lineParts[0], lineParts[1], other);
                    hostEntries.Add(hostEntry);
                }
            }

            return hostEntries;
        }

        public List<HostEntry> FilterHostEntries(EntryType type, string filterValue, List<HostEntry> hostEntries = null)
        {
            throw new NotImplementedException();
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
    }
}