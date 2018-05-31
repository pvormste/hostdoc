using System;
using System.Collections.Generic;
using System.IO;
using HostDoc.Core.Definitions;
using HostDoc.Core.Extensions;
using HostDoc.Core.Types;

namespace HostDoc.Core.Services
{
    public abstract class HostService : IHostService
    {

        private string hostLocation;


        public string HostLocation
        {
            get => hostLocation;
            set => hostLocation = value;
        }


        public abstract string GetHostFileLocation();
        
        public List<HostEntry> ReadHostEntries()
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
                    
                        var hostEntry = new HostEntry(lineParts[0], lineParts[1], other);
                        hostEntries.Add(hostEntry);
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

        public bool RemoveHostEntry(HostEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
