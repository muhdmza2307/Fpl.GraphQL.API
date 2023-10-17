using Fpl.Portal.Common.Configuration.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fpl.Portal.GraphQL
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomMvcOptions(this IMvcBuilder builder,
            IConfiguration configuration) =>
            builder.AddMvcOptions( opts =>
            {
                var cacheProfileOptions = configuration
                .GetSection(nameof(ApplicationOptions.CacheProfiles))
                .Get<CacheProfileOptions>();

                if (cacheProfileOptions != null)
                {
                    foreach (var keyVal in cacheProfileOptions)
                    {
                        opts.CacheProfiles.Add(keyVal);
                    }
                }

                opts.OutputFormatters.RemoveType<StringOutputFormatter>();

                opts.ReturnHttpNotAcceptable = true;
            });
    }
}
