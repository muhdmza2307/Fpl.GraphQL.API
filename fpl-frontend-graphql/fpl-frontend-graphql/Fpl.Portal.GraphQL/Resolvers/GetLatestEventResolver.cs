using System.Threading.Tasks;
using Fpl.Portal.Handlers.Events;
using Fpl.Portal.Models.Events;
using HotChocolate;

namespace Fpl.Portal.GraphQL.Resolvers;

public class GetLatestEventResolver
{
    public async Task<EventResult> GetLatestEventAsync(
        [Service] IGetLatestEventHandler getLatestEventHandler) =>
        await getLatestEventHandler
            .HandleAsync()
            .ConfigureAwait(false);
}