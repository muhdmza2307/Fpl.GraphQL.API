using Fpl.Portal.Models.Enums;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types.EnumTypes;

public class StatIdentifierTypeEnumObject : EnumType<StatIdentifier>
{
    protected override void Configure(IEnumTypeDescriptor<StatIdentifier> descriptor)
    {
        descriptor.Name("StatIdentifier");

        descriptor.Value(StatIdentifier.GoalsScored).Name("GoalsScored");
        descriptor.Value(StatIdentifier.Assists).Name("Assists");
        descriptor.Value(StatIdentifier.OwnGoals).Name("OwnGoals");
        descriptor.Value(StatIdentifier.PenaltiesSaved).Name("PenaltiesSaved");
        descriptor.Value(StatIdentifier.PenaltiesMissed).Name("PenaltiesMissed");
        descriptor.Value(StatIdentifier.YellowCards).Name("YellowCards");        
        descriptor.Value(StatIdentifier.RedCards).Name("RedCards");
        descriptor.Value(StatIdentifier.Saves).Name("Saves");
        descriptor.Value(StatIdentifier.Bonus).Name("Bonus");
        descriptor.Value(StatIdentifier.Bps).Name("Bps");
    }
}