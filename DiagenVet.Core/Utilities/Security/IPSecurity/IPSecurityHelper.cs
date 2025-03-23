using System.Net;
using Microsoft.AspNetCore.Http;

namespace DiagenVet.Core.Utilities.Security.IPSecurity
{
    public static class IPSecurityHelper
    {
        private static readonly HashSet<string> _blacklistedIPs = new HashSet<string>();
        private static readonly Dictionary<string, int> _requestCounts = new Dictionary<string, int>();
        private static readonly Dictionary<string, DateTime> _lastRequestTimes = new Dictionary<string, DateTime>();

        public static void AddToBlacklist(string ip)
        {
            _blacklistedIPs.Add(ip);
        }

        public static void RemoveFromBlacklist(string ip)
        {
            _blacklistedIPs.Remove(ip);
        }

        public static bool IsBlacklisted(string ip)
        {
            return _blacklistedIPs.Contains(ip);
        }

        public static bool CheckRequestLimit(string ip, int maxRequests, TimeSpan timeWindow)
        {
            var now = DateTime.UtcNow;

            if (!_requestCounts.ContainsKey(ip))
            {
                _requestCounts[ip] = 1;
                _lastRequestTimes[ip] = now;
                return true;
            }

            var timeSinceLastRequest = now - _lastRequestTimes[ip];
            if (timeSinceLastRequest > timeWindow)
            {
                _requestCounts[ip] = 1;
                _lastRequestTimes[ip] = now;
                return true;
            }

            if (_requestCounts[ip] >= maxRequests)
            {
                return false;
            }

            _requestCounts[ip]++;
            return true;
        }

        public static string GetClientIPAddress(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress?.ToString();
            }
            return ip ?? "Unknown";
        }
    }
} 