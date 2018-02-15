using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HostDoc.Core.Models;
using HostDoc.Core.Types;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : IHostService
    {
        const string hostLocation = @"C:\Windows\System32\drivers\etc\hosts";
        
        public List<HostEntry> ReadHostEntries()
        {
            List<HostEntry> hostEntries = new List<HostEntry>();
            
            using (StreamReader sr = new StreamReader(hostLocation))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    // Check if line is relevant
                    var regex = new Regex(@"\s+");
                    line = regex.Replace(line, " ");
                    line = line.Trim();
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;
                    
                    // Extract the entries
                    string[] lineParts = line.Split(' ');
                    string other = null;
                    if (lineParts.Length > 2)
                    {
                        string[] otherParts = new string[lineParts.Length - 2];
                        for (int i = 2; i < lineParts.Length; i++)
                        {
                            otherParts[i - 2] = lineParts[i];
                        }

                        other = string.Join(" ", otherParts);
                    }
                    
                    var hostEntry = new HostEntry(lineParts[0], lineParts[1], other);
                    hostEntries.Add(hostEntry);
                }
            }

            return hostEntries;
        }

        public List<HostEntry> FilterHostEntries(FilterType type, string filterValue, List<HostEntry> hostEntries = null)
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
    }
}