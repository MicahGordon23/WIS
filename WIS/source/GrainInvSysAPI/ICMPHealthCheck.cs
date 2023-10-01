using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;
namespace GrainInvSysAPI
{ 
    public class ICMPHealthCheck : IHealthCheck
    {
        private readonly string Host = $"10.0.0.0";
        private readonly int HealthyRoundtripTime = 100;
        
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
                        return (reply.RoundtripTime > HealthyRoundtripTime) 
                            ? HealthCheckResult.Degraded() : HealthCheckResult.Healthy();
                    default:
                        return HealthCheckResult.Unhealthy();
                }
            }
            catch (Exception e) 
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
