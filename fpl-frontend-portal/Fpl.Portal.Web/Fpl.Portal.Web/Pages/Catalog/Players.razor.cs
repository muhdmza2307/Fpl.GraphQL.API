using Fpl.Portal.Web.Models.Players;
using FplPortal.Web.Services.FplDataServices.Players;
using Microsoft.AspNetCore.Components;

namespace Fpl.Portal.Web.Pages.Catalog;

public partial class Players
{
    [Inject]
    public IPlayerService PlayerService { get; set; } = null!;
    private IEnumerable<Player>? PlayersList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PlayersList = await PlayerService
            .GetPlayerList()
            .ConfigureAwait(false);
    }

    private IOrderedEnumerable<IGrouping<int, Player>> GetGroupedPlayersByTeam()
    { 
        return PlayersList!
            .OrderByDescending(player => Convert.ToDecimal(player.Form))
            .GroupBy(player => player.Team)
            .OrderBy(playerByTeam => playerByTeam.Key);
    }

    private string GetTeamName(IGrouping<int, Player> groupedPlayers)
    {
        return groupedPlayers
            .FirstOrDefault(p => p.Team == groupedPlayers.Key)!
            .Team.ToString();
    }
}