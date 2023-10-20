using Fpl.Portal.Models.Teams;

namespace Fpl.Portal.Handlers.Teams;

public interface IGetTeamListHandler
{
    Task<IEnumerable<TeamResult>> HandleAsync();
}