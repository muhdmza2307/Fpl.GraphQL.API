using Fpl.Portal.Web.Models.FplGraphQlResponse;
using Fpl.Portal.Web.Models.Players;
using Fpl.Portal.Web.Repository.Repositories;

namespace Fpl.Portal.Web.Repository.Queries.FplQueries;

public class GetPlayerListQuery :
    IGraphQlQuery<FplGraphQlResponse<Player>, IEnumerable<Player>>
{
    public GetPlayerListQuery()
    {
        Variables = new {  };
    }

    public string Query
        => @"query{
              playerList{
                id
                code
                webName
                photo
                news
                team
                teamName
                form
                goalsScored
                assists
                cleanSheets
                goalsConceded
              }
            }";

    public object? Variables { get; }

    public IEnumerable<Player> ExtractResult(FplGraphQlResponse<Player> response)
        => response.PlayerList ?? Array.Empty<Player>();
}