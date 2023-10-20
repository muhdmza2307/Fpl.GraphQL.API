using System.Collections.Generic;
using System.Threading.Tasks;
using Fpl.Portal.Handlers.Teams;
using Fpl.Portal.Models.Teams;
using HotChocolate;


namespace Fpl.Portal.GraphQL.Resolvers;

public class GetTeamsResolver
{
    public async Task<IEnumerable<TeamResult>> GetTeamListAsync(
        [Service] IGetTeamListHandler getTeamListHandler) =>
        await getTeamListHandler
            .HandleAsync()
            .ConfigureAwait(false);
}
        
