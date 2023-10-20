using Fpl.Portal.GraphQL.Resolvers;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types;

public class GetPlayersObject : ObjectTypeExtension<GetPlayersResolver>
{
    protected override void Configure(IObjectTypeDescriptor<GetPlayersResolver> descriptor)
    {
        descriptor.Name("Query")
            .Field(x => x.GetPlayerListAsync(default!))
            .Description("Return EPL Player List");
    }
}