using Fpl.Portal.Web.Models.Teams;
using FplPortal.Web.Services.FplDataServices.Teams;
using Microsoft.AspNetCore.Components;

namespace Fpl.Portal.Web.Pages.Catalog;

public partial class Teams
{
    [Inject]
    public ITeamService TeamService { get; set; } = null!;
    
    private IEnumerable<Team>? TeamsList { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        TeamsList = await TeamService
            .GetTeamList()
            .ConfigureAwait(false);
    }
}