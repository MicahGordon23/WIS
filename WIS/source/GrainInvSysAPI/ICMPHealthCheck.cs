using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;

// TO delete file for practice
namespace GrainInvSysAPI
{ 
    public class ICMPHealthCheck : IHealthCheck
    { 
        private readonly string Host;
        private readonly int HealthyRoundtripTime;
        
        public ICMPHealthCheck(string host, int healthyRoundtripTime)
        {
            Host = host;
            HealthyRoundtripTime = healthyRoundtripTime;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                using Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(Host);
                switch (reply.Status)
                {
                    case IPStatus.Success:
                        string msg = $"ICMP to (Host) took (replay.RoundtripTime) ms.";
                        return (reply.RoundtripTime > HealthyRoundtripTime) ? 
                            HealthCheckResult.Degraded(msg) : HealthCheckResult.Healthy(msg);
                    default:
                        {
                            string err = $"ICMP to (Host) failed: (reply.Status)";
                            return HealthCheckResult.Unhealthy(err);
                        }
                }
            }
            catch (Exception e) 
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
