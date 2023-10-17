using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Handlers.Fixtures;

public interface IGetFixtureByIdHandler
{
    Task<FixturesResult> HandleAsync(GetFixturesInput request);
}