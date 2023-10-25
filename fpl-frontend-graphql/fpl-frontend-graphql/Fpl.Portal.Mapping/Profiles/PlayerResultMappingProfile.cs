using AutoMapper;
using Fpl.Portal.Mapping.Resolvers;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Players;

namespace Fpl.Portal.Mapping.Profiles;

public class PlayerResultMappingProfile : Profile
{
    public PlayerResultMappingProfile()
    {
        CreateMap<Player, PlayerResult>()
            .ForMember(dest => dest.TeamName, opts => opts.MapFrom<TeamNameResolver>());
    }
}