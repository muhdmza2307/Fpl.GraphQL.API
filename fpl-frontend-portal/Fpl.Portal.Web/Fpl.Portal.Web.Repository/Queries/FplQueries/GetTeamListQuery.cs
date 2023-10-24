using Fpl.Portal.Web.Models.FplGraphQlResponse;
using Fpl.Portal.Web.Models.Teams;
using Fpl.Portal.Web.Repository.Repositories;

namespace Fpl.Portal.Web.Repository.Queries.FplQueries;

public class GetTeamListQuery :
    IGraphQlQuery<FplGraphQlResponse<Team>, IEnumerable<Team>>
{
    public GetTeamListQuery()
    {
        Variables = new {  };
    }

    public string Query
        => @"query{
              teamList{
                id
                code
                name
                shortName
              }
            }";
    
    public object? Variables { get; }

    public IEnumerable<Team> ExtractResult(FplGraphQlResponse<Team> response)
        => response.TeamList ?? Array.Empty<Team>();
}