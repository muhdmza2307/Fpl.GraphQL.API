using Fpl.Portal.GraphQL.Resolvers;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types;

public class GetTeamsObject : ObjectTypeExtension<GetTeamsResolver>
{
    protected override void Configure(IObjectTypeDescriptor<GetTeamsResolver> descriptor)
    {
        descriptor.Name("Query")
            .Field(x => x.GetTeamListAsync(default!))
            .Description("Return EPL Team List");
    }
}