using System.Collections.Generic;
using HostDoc.Core.Models;
using HostDoc.Core.Types;

namespace HostDoc.Core.Services
{
    public interface IHostService
    {
        string GetHostFileLocation();
        List<HostEntry> ReadHostEntries();
        List<HostEntry> FilterHostEntries(FilterType type, string filterValue, List<HostEntry> hostEntries = null);
        bool AddHostEntry(HostEntry hostEntry);
        bool AddMultipleHostEntries(List<HostEntry> hostEntries);
    }
}
