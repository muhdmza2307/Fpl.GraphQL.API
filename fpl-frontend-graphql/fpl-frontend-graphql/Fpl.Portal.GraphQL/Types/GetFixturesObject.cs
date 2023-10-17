using Fpl.Portal.GraphQL.Resolvers;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types;

public class GetFixturesObject : ObjectTypeExtension<GetFixturesResolver>
{
    protected override void Configure(IObjectTypeDescriptor<GetFixturesResolver> descriptor)
    {
        descriptor.Name("Query")
            .Field(x => x.GetFixturesByEventIdAsync(default!, default!))
            .Description("Returns a list of fixtures by event Id");
    }
}