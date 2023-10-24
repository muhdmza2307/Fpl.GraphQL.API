using Fpl.Portal.Web.Repository.Repositories.Interfaces;

namespace Fpl.Portal.Web.Repository.Repositories;

public class FplGraphQlRepository : GraphQlRepository, IFplGraphQlRepository
{
    public FplGraphQlRepository(IFplGraphQlClient client)
        : base(client)
    {
    }
}