using Fpl.Portal.Web;
using Fpl.Portal.Web.Common.Configuration.Options;
using Fpl.Portal.Web.Repository.Repositories;
using Fpl.Portal.Web.Repository.Repositories.Interfaces;
using FplPortal.Web.Services.FplDataServices.Players;
using FplPortal.Web.Services.FplDataServices.Teams;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
var fplGraphQlOptions = builder.Configuration.GetSection("FplGraphQL").Get<FplGraphQLOptions>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IFplGraphQlRepository, FplGraphQlRepository>();
builder.Services.AddTransient<IFplGraphQlClient>(_ => new FplGraphQlClient(fplGraphQlOptions.BaseUrl, new NewtonsoftJsonSerializer()));

await builder.Build().RunAsync();




