using Fpl.Portal.Web.Models.Players;
using FplPortal.Web.Services.FplDataServices.Players;
using Microsoft.AspNetCore.Components;

namespace Fpl.Portal.Web.Pages.Catalog;

public partial class TeamPlayers
{
    [Parameter]
    public int TeamId { get; set; }
    [Inject]
    public IPlayerService PlayerService { get; set; } = null!;
    private IEnumerable<Player>? TeamPlayersList { get; set; }
    private string TeamName { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        var players = (await PlayerService
            .GetPlayerList()
            .ConfigureAwait(false)).ToList();

        TeamPlayersList = players
            .Where(player => player.Team == TeamId)
            .OrderByDescending(player => Convert.ToDecimal(player.Form));

        TeamName = TeamPlayersList.FirstOrDefault()!.TeamName;
    }
}