using Boxed.AspNetCore;
using Fpl.Portal.Common.Constants;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fpl.Portal.GraphQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpClient()
                .AddCustomCaching()
                .AddCustomCors()
                .AddCustomOptions(_configuration)
                .AddCustomRouting()
                .AddCustomResponseCompression(_configuration)
                .AddCustomHealthChecks()
                .AddServerTiming()
                .AddControllers()
                .AddCustomMvcOptions(_configuration)
                .Services
                .AddHttpContextAccessor()
                .AddCustomGraphQL(_configuration)
                .AddProjectServices()
                .AddProjectFunctionCallers()
                .AddProjectHandlers()
                .RegisterAutoMapper();
        }

        public virtual void Configure(IApplicationBuilder application) =>
            application
                .UseIf(
                    _webHostEnvironment.IsDevelopment(),
                    x => x.UseServerTiming())
                .UseForwardedHeaders()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseCors(CorsPolicyName.AllowAny)
                .UseResponseCompression()
                .UseIf(
                    _webHostEnvironment.IsDevelopment(),
                    x => x.UseDeveloperExceptionPage())
                .UseStaticFilesWithCacheControl()
                .UseEndpoints(
                    builder => {
                        var options = new GraphQLServerOptions();
                        options.Tool.Enable = false;

                        // Map the GraphQL HTTP and web socket endpoint at /graphql.
                        builder.MapGraphQL().WithOptions(options);
                        
                        // Map the GraphQL Playground UI to try out the GraphQL API at /.
                        builder.MapGraphQLPlayground("/"); 
                        // Map the GraphQL Voyager UI to let you navigate your GraphQL API as a spider graph at /voyager.
                        builder.MapGraphQLVoyager("/voyager"); 
                        // Map the GraphQL Banana Cake Pop UI to let you navigate your GraphQL API at /banana.
                        builder.MapBananaCakePop("/banana");

                        // Map health check endpoints.
                        builder
                        .MapHealthChecks("/status")
                        .RequireCors(CorsPolicyName.AllowAny);

                        builder
                        .MapHealthChecks("/status/self", new HealthCheckOptions() { Predicate = _ => false })
                        .RequireCors(CorsPolicyName.AllowAny); });
    }
}
