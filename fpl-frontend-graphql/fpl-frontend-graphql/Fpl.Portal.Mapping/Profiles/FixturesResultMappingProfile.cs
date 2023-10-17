using AutoMapper;
using Fpl.Portal.Mapping.Resolvers;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Mapping.Profiles;

public class FixturesResultMappingProfile : Profile
{
    public FixturesResultMappingProfile()
    {
        CreateMap<FixtureQueryResponse, FixturesResult>()
            .ForMember(dest => dest.FixtureCode, opts => opts.MapFrom(src => src.Code))
            .ForMember(dest => dest.EventId, opts => opts.MapFrom(src => src.Event))
            .ForMember(dest => dest.FixtureId, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.KickOffDateTime, opts => opts.MapFrom(src => src.KickoffTime))
            .ForMember(dest => dest.AwayTeam, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<TeamInfo>(context.Options.Items["AwayTeam"])))
            .ForMember(dest => dest.HomeTeam, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<TeamInfo>(context.Options.Items["HomeTeam"])))
            .ForMember(dest => dest.Stats, opts => opts.MapFrom<StatsResolver>());

        CreateMap<Team, TeamInfo>();
    }
}