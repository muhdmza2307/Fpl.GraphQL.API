using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Teams;

namespace Fpl.Portal.Mapping.Profiles;

public class TeamResultMappingProfile : Profile
{
    public TeamResultMappingProfile()
    {
        CreateMap<Team, TeamResult>();
    }
}