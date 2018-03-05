using System.Net;

namespace HostDoc.Core.Definitions
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

        public override string ToString()
        {
            return $"{IpAddress}\t\t{Hostname}\t\t{OtherToString()}";
        }

        string OtherToString()
        {
            if (string.IsNullOrWhiteSpace(Other))
                return "";
            
            return Other.StartsWith("#") ? $"{Other}" : $"# {Other}";
        }
    }
}