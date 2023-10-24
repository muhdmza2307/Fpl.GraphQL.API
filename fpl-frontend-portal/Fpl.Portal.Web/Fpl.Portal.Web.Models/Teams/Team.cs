using Fpl.Portal.Web.Models.FplGraphQlResponse;

namespace Fpl.Portal.Web.Models.Teams;

public class Team : IGraphQlDataResponse
{
    public int Id { get; set; }
    public long Code { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
}