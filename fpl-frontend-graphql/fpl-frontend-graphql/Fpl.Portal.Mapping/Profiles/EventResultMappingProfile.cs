using AutoMapper;
using Fpl.Portal.Common.Extensions;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Enums;
using Fpl.Portal.Models.Events;

namespace Fpl.Portal.Mapping.Profiles;

public class EventResultMappingProfile : Profile
{
    public EventResultMappingProfile()
    {
        CreateMap<Event, EventResult>()
            .ForMember(dest => dest.MostSelectedPlayer, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<PlayerInfo>(context.Options.Items["MostSelectedPlayer"])))
            .ForMember(dest => dest.MostTransferredInPlayer, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<PlayerInfo>(context.Options.Items["MostTransferredInPlayer"])))
            .ForMember(dest => dest.MostCaptainedPlayer, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<PlayerInfo>(context.Options.Items["MostCaptainedPlayer"])))
            .ForMember(dest => dest.MostViceCaptainedPlayer, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<PlayerInfo>(context.Options.Items["MostViceCaptainedPlayer"])))
            .ForMember(dest => dest.TopPlayer, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<PlayerScoreInfo>(context.Options.Items["TopPlayer"])))
            .ForMember(dest => dest.StrategyPlays, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<List<StrategyInfo>>(src.ChipPlays)));

        CreateMap<ChipPlay, StrategyInfo>()
            .ForMember(dest => dest.StrategyTypeName, opts => opts.MapFrom(src => src.ChipName.GetEnumValueFromDescription<StrategyType>()))
            .ForMember(dest => dest.TotalPlayed, opts => opts.MapFrom(src => src.NumPlayed));
        
        CreateMap<Player, PlayerInfo>()
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.WebName));

        CreateMap<Player, PlayerScoreInfo>()
            .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.WebName))
            .ForMember(dest => dest.Points, opts => opts.MapFrom((src, dest, _, context) =>
                context.Mapper.Map<int>(context.Options.Items["TopPlayerPoints"])));
    }
}