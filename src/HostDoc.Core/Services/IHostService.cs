using System.Collections.Generic;
using HostDoc.Core.Models;

namespace HostDoc.Core.Services
{
    public interface IHostService
    {
        List<HostEntry> ReadHostEntries();
    }
}
