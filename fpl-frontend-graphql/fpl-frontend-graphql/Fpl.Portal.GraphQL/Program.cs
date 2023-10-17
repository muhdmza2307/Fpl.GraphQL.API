using Boxed.AspNetCore;
using Fpl.Portal.Common.Configuration.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Fpl.Portal.GraphQL;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        IHostEnvironment? hostEnvironment = null!;
        try
        {
            Log.Information("Starting web host");
            var host = CreateHostBuilder(args).Build();
            hostEnvironment = host.Services.GetRequiredService<IHostEnvironment>();
            hostEnvironment.ApplicationName = AssemblyInformation.Current.Product;

            await host.RunAsync().ConfigureAwait(false);
            return 0;
        }
        catch (Exception e)
        {
            Log.Fatal(e, $"{AssemblyInformation.Current.Product} terminated unexpectedly in {hostEnvironment?.EnvironmentName} mode.");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        new HostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureHostConfiguration(configurationBuilder => 
                configurationBuilder.AddEnvironmentVariables(prefix: "DOTNET_")
                .AddIf(args is not null, x => 
                    x.AddCommandLine(args)))
            .ConfigureAppConfiguration((hostContext, config) =>
                AddConfiguration(config, hostContext.HostingEnvironment, args))
            .UseSerilog((ctx, config) =>
            {
                config.ReadFrom.Configuration(ctx.Configuration);
            })
            .UseDefaultServiceProvider((context, options) =>
            {
                var isLocalOrDevelopment = context.HostingEnvironment.IsLocalOrDevelopment();
                options.ValidateScopes = isLocalOrDevelopment;
                options.ValidateOnBuild = isLocalOrDevelopment;
            })
            .ConfigureWebHost(ConfigureWebHostBuilder)
            .UseConsoleLifetime();

    private static void ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder) =>
        webHostBuilder
            .UseKestrel((builderContext, options) =>
                {
                    options.AddServerHeader = false;
                    options.Configure(builderContext.Configuration.GetSection(nameof(ApplicationOptions.Kestrel)),
                        reloadOnChange: false);
                })
            .UseIIS()
            .ConfigureServices(services => services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true))
            .UseStartup<Startup>();

    private static void AddConfiguration(IConfigurationBuilder configurationBuilder,
        IHostEnvironment hostEnvironment,
        string[] args)
    {
        configurationBuilder
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false)
            .AddKeyPerFile(Path.Combine(Directory.GetCurrentDirectory(), "configuration"), optional: true, reloadOnChange: false)
            .AddIf(hostEnvironment.IsDevelopment() && !string.IsNullOrEmpty(hostEnvironment.ApplicationName) ||
                hostEnvironment.IsEnvironment("Staging") && 
                !string.IsNullOrEmpty(hostEnvironment.ApplicationName) || 
                hostEnvironment.IsEnvironment("Local"), 
                x => x.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true, reloadOnChange: false))
            .AddEnvironmentVariables()
            .AddIf(
                args is not null, 
                x => x.AddCommandLine(args));
    }

}