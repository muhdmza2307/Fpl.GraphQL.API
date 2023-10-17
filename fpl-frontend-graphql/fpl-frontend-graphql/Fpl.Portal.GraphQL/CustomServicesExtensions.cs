using Boxed.AspNetCore;
using HotChocolate.Execution.Options;
using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Fpl.Portal.GraphQL.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Fpl.Portal.GraphQL
{
    internal static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomCaching(this IServiceCollection services) =>
            services.AddMemoryCache();

        public static IServiceCollection AddCustomCors(this IServiceCollection services) =>
            services.AddCors(opts =>
                opts.AddPolicy(
                    CorsPolicyName.AllowAny,
                    x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

        public static IServiceCollection AddCustomOptions(this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddSingleton<JsonSerializerConfigOptions>()
                .ConfigureAndValidateSingleton<ApiEndPointsOptions>(configuration.GetSection("FplApi:EndPoints"))
                .ConfigureAndValidateSingleton<ApiFunctionOptions>(configuration.GetSection("ApiFunction"))
                .ConfigureAndValidateSingleton<ApplicationOptions>(configuration)
                .ConfigureAndValidateSingleton<CacheProfileOptions>(configuration.GetSection(nameof(ApplicationOptions.CacheProfiles)))
                .ConfigureAndValidateSingleton<CompressionOptions>(configuration.GetSection(nameof(ApplicationOptions.Compression)))
                .ConfigureAndValidateSingleton<ForwardedHeadersOptions>(configuration.GetSection(nameof(ApplicationOptions.ForwardedHeaders)))
                .Configure<ForwardedHeadersOptions>(options => { 
                    options.KnownNetworks.Clear();
                    options.KnownProxies.Clear(); 
                })
                .ConfigureAndValidateSingleton<GraphQLOptions>(configuration.GetSection(nameof(ApplicationOptions.GraphQL)))
                .ConfigureAndValidateSingleton<RequestExecutorOptions>(configuration.GetSection(nameof(GraphQLOptions.Request)))
                .ConfigureAndValidateSingleton<KestrelServerOptions>(configuration.GetSection(nameof(ApplicationOptions.Kestrel)));

        public static IServiceCollection AddCustomResponseCompression(this IServiceCollection services, 
            IConfiguration configuration) => 
            services
                .Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
                .AddResponseCompression(options => { 
                    // Add additional MIME types (other than the built in defaults) to enable GZIP compression for.
                    var customMimeTypes = configuration
                        .GetSection(nameof(ApplicationOptions.Compression))
                        .Get<CompressionOptions>() 
                        ?.MimeTypes ?? Enumerable.Empty<string>(); 
                    options.MimeTypes = customMimeTypes.Concat(ResponseCompressionDefaults.MimeTypes);

                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>(); 
                });

        public static IServiceCollection AddCustomRouting(this IServiceCollection services) =>
            services.AddRouting(opts => opts.LowercaseUrls = true);

        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services,
            IConfiguration configuration)
        {
            var graphQLOptions = configuration.GetSection(nameof(ApplicationOptions.GraphQL)).Get<GraphQLOptions>();
            return (IServiceCollection)services
                .AddGraphQLServer()
                .AddFiltering()
                .AddSorting()
                .AddGlobalObjectIdentification()
                .AddQueryFieldToMutationPayloads()
                .AddApolloTracing()
                .AddAuthorization()
                .AddProjectScalarTypes()
                .AddProjectDirectives()
                .AddProjectDataLoaders()
                .AddProjectTypes()
                .TrimTypes()
                .ModifyOptions(opts => opts.UseXmlDocumentation = false)
                .AddMaxExecutionDepthRule(graphQLOptions.MaxAllowedExecutionDepth)
                .SetPagingOptions(graphQLOptions.Paging)
                .SetRequestOptions(() => graphQLOptions.Request)
                .AddDiagnosticEventListener(sp => new LoggingExecutionDiagnosticsEventListener(sp
                    .GetApplicationService<ILogger<LoggingExecutionDiagnosticsEventListener>>()))
                .Services;
        }

        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services) =>
                services
                .AddHealthChecks()
            .Services;
    }
    
}
