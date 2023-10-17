using AutoMapper;
using Fpl.Portal.Common.Extensions;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Enums;
using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Mapping.Resolvers;

public class StatsResolver :  IValueResolver<FixtureQueryResponse, FixturesResult, IEnumerable<Stat>>
{
    public IEnumerable<Stat> Resolve(FixtureQueryResponse source,
        FixturesResult destination,
        IEnumerable<Stat> destMember,
        ResolutionContext context) =>
        source.Stats!
            .Select(stat =>
                CreateStat(stat.Identifier,
                    stat.AwayStats, 
                    stat.HomeStats, 
                    context))
            .ToList();

    private static Stat CreateStat(string statIdentifier,
        IEnumerable<FixtureStatValueQueryResponse> fixtureAwayStatValues,
        IEnumerable<FixtureStatValueQueryResponse>?fixtureHomeStatValues,
        ResolutionContext context)
    {
        return new Stat()
        {
            StatIdentifierName = statIdentifier.GetEnumValueFromDescription<StatIdentifier>(),
            AwayStatInfo = CreateStatInformation(fixtureAwayStatValues!, context),
            HomeStatInfo = CreateStatInformation(fixtureHomeStatValues!, context)
        };
    }

    private static IEnumerable<StatInformation> CreateStatInformation(IEnumerable<FixtureStatValueQueryResponse> fixtureStatValues, ResolutionContext context)
    {
        var players = context.Options.Items["Players"] as IEnumerable<Player>;

        return fixtureStatValues.Select(MapInfo).ToList();
        
        

        // Local Function
        StatInformation MapInfo(FixtureStatValueQueryResponse fixtureStatValueQueryResponse)
        {
            var info = new StatInformation
            {
                Value = fixtureStatValueQueryResponse.Value,
                Label = new Label
                {
                    LabelId = players?
                        .FirstOrDefault(player => player.Id == fixtureStatValueQueryResponse.Element)?
                        .Id ?? 0,
                    LabelName = players?
                        .FirstOrDefault(player => player.Id == fixtureStatValueQueryResponse.Element)?
                        .WebName ?? String.Empty
                }
            };

            return info;
        }
    }
}