using Fpl.Portal.GraphQL.Resolvers;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types;

public class GetEventsObject : ObjectTypeExtension<GetLatestEventResolver>
{
    protected override void Configure(IObjectTypeDescriptor<GetLatestEventResolver> descriptor)
    {
        descriptor.Name("Query")
            .Field(x => x.GetLatestEventAsync(default!))
            .Description("Return Latest Event");
    }
}