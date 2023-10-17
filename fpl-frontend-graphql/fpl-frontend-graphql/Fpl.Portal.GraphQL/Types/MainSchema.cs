using HotChocolate;
using HotChocolate.Types;

namespace Fpl.Portal.GraphQL.Types
{
    public class MainSchema : Schema
    {
        protected override void Configure(ISchemaTypeDescriptor descriptor) =>
            descriptor.Description("This is main schema");
    }
}
