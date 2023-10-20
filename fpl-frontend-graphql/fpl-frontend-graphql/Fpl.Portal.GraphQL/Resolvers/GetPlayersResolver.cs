using System.Collections.Generic;
using System.Threading.Tasks;
using Fpl.Portal.Handlers.Players;
using Fpl.Portal.Models.Players;
using HotChocolate;

namespace Fpl.Portal.GraphQL.Resolvers;

public class GetPlayersResolver
{
    public async Task<IEnumerable<PlayerResult>> GetPlayerListAsync(
        [Service] IGetPlayerListHandler getPlayerListHandler) =>
        await getPlayerListHandler
            .HandleAsync()
            .ConfigureAwait(false);
}