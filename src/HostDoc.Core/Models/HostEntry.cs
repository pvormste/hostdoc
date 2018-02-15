using System.Net;

namespace HostDoc.Core.Models
{
    public class HostEntry
    {
        public IPAddress IpAddress { get; set; }
        public string Hostname { get; set; }
        public string Other { get; set; }
    }
}