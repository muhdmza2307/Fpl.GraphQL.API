using Fpl.Portal.Models.Enums;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types.EnumTypes;

public class StrategyTypeEnumObject : EnumType<StrategyType>
{
    protected override void Configure(IEnumTypeDescriptor<StrategyType> descriptor)
    {
        descriptor.Name("StrategyType");

        descriptor.Value(StrategyType.BenchBoost).Name("BenchBoost");
        descriptor.Value(StrategyType.FreeHit).Name("FreeHit");
        descriptor.Value(StrategyType.WildCard).Name("WildCard");
        descriptor.Value(StrategyType.TripleCapt).Name("TripleCapt");
    }
}