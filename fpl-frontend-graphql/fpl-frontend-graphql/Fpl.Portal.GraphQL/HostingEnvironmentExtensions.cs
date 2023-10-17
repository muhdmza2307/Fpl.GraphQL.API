using Microsoft.Extensions.Hosting;

namespace Fpl.Portal.GraphQL
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsLocalOrDevelopment(this IHostEnvironment env) =>
            env.IsEnvironment("Local") || env.IsDevelopment();
    }
}
