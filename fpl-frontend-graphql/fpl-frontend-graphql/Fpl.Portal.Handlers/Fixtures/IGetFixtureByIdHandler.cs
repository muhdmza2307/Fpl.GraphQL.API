using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Handlers.Fixtures;

public interface IGetFixturesByEventIdHandler
{
    Task<IEnumerable<FixturesResult>> HandleAsync(GetFixturesInput request);
}