using Fpl.Portal.Web.Models.Teams;
using Fpl.Portal.Web.Repository.Queries.FplQueries;
using Fpl.Portal.Web.Repository.Repositories.Interfaces;

namespace FplPortal.Web.Services.FplDataServices.Teams;

public class TeamService : ITeamService
{
    private readonly IFplGraphQlRepository _fplGraphQlRepository;
    
    public TeamService(IFplGraphQlRepository fplGraphQlRepository)
    {
        _fplGraphQlRepository = fplGraphQlRepository;
    }
    
    public async Task<IEnumerable<Team>> GetTeamList() =>
        await _fplGraphQlRepository
            .QueryAsync(new GetTeamListQuery())
            .ConfigureAwait(false);
}