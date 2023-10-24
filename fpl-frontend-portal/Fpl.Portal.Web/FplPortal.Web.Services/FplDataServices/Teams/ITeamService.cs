using Fpl.Portal.Web.Models.Teams;

namespace FplPortal.Web.Services.FplDataServices.Teams;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetTeamList();
}