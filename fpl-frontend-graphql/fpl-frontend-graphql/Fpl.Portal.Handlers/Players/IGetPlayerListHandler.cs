using Fpl.Portal.Models.Players;

namespace Fpl.Portal.Handlers.Players;

public interface IGetPlayerListHandler
{
    Task<IEnumerable<PlayerResult>> HandleAsync();
}