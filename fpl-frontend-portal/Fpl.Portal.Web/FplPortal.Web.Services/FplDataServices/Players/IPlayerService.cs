using Fpl.Portal.Web.Models.Players;

namespace FplPortal.Web.Services.FplDataServices.Players;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetPlayerList();
}