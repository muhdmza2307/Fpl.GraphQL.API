using AutoMapper;
using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Mapping.Profiles;

public class StatInformationMappingProfile : Profile
{
    public StatInformationMappingProfile()
    {
        CreateMap<FixtureStatValueQueryResponse, StatInformation>()
            .ForMember(dest => dest.Label, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<StatInformation>(dest)));

        CreateMap<FixtureStatValueQueryResponse, Label>()
            .ForMember(dest => dest.LabelId, opts => opts.MapFrom(src => src.Element))
            .ForMember(dest => dest.LabelName, opt => opt.Ignore());
    }
}