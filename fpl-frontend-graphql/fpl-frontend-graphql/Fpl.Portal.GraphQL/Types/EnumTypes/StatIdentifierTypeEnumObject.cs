using Fpl.Portal.Models.Enums;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types.EnumTypes;

public class StatIdentifierTypeEnumObject : EnumType<StatIdentifier>
{
    protected override void Configure(IEnumTypeDescriptor<StatIdentifier> descriptor)
    {
        descriptor.Name("StatIdentifier");

        descriptor.Value(StatIdentifier.GoalsScored).Name("goals_scored");
        descriptor.Value(StatIdentifier.Assists).Name("assists");
        descriptor.Value(StatIdentifier.OwnGoals).Name("own_goals");
        descriptor.Value(StatIdentifier.PenaltiesSaved).Name("penalties_saved");
        descriptor.Value(StatIdentifier.PenaltiesMissed).Name("penalties_missed");
        descriptor.Value(StatIdentifier.YellowCards).Name("yellow_cards");        
        descriptor.Value(StatIdentifier.RedCards).Name("red_cards");
        descriptor.Value(StatIdentifier.Saves).Name("saves");
        descriptor.Value(StatIdentifier.Bonus).Name("bonus");
        descriptor.Value(StatIdentifier.Bps).Name("bps");
    }
}