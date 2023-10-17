using System.Collections.Generic;
using System.Threading.Tasks;
using Fpl.Portal.Handlers.Fixtures;
using Fpl.Portal.Models.Fixtures;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using HotChocolate;

namespace Fpl.Portal.GraphQL.Resolvers;

public class GetFixturesResolver
{
    public async Task<IEnumerable<FixturesResult>> GetFixturesByEventIdAsync(
        [Service] IGetFixturesByEventIdHandler getFixtureByIdHandler,
        GetFixturesInput input) =>
        await getFixtureByIdHandler
            .HandleAsync(input)
            .ConfigureAwait(false);
 
}