using Fpl.Portal.Web.Models.Players;
using Fpl.Portal.Web.Repository.Queries.FplQueries;
using Fpl.Portal.Web.Repository.Repositories.Interfaces;

namespace FplPortal.Web.Services.FplDataServices.Players;

public class PlayerService : IPlayerService
{
    private readonly IFplGraphQlRepository _fplGraphQlRepository;

    public PlayerService(IFplGraphQlRepository fplGraphQlRepository)
    {
        _fplGraphQlRepository = fplGraphQlRepository;
    }

    public async Task<IEnumerable<Player>> GetPlayerList() =>
        await _fplGraphQlRepository
            .QueryAsync(new GetPlayerListQuery())
            .ConfigureAwait(false);
}