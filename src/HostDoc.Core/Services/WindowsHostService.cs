using System;
using System.Collections.Generic;
using System.IO;
using HostDoc.Core.Models;

namespace HostDoc.Core.Services
{
    public class WindowsHostService : IHostService
    {
        const string hostLocation = @"C:\Windows\System32\drivers\etc\hosts";
        
        public List<HostEntry> ReadHostEntries()
        {
            using (StreamReader sr = new StreamReader(hostLocation))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;
                    
                    Console.WriteLine(line);
                }
            }

            return null;
        }
    }
}