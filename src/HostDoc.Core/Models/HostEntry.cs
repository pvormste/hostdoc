using System.Net;

namespace HostDoc.Core.Models
{
    public class HostEntry
    {
        public IPAddress IpAddress { get; set; }
        public string Hostname { get; set; }
        public string Other { get; set; }

        public HostEntry()
        {
        }

        public HostEntry(string ipAddress, string hostname, string other = null)
        {
            IpAddress = IPAddress.Parse(ipAddress);
            Hostname = hostname;
            Other = other;
        }
    }
}