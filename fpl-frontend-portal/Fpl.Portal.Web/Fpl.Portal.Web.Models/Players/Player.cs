using Fpl.Portal.Web.Models.FplGraphQlResponse;

namespace Fpl.Portal.Web.Models.Players;

public class Player : IGraphQlDataResponse
{
    public int Code { get; set; }
    public int Id { get; set; }
    public string News { get; set; } = null!;
    public string Photo { get; set; } = null!;
    public string WebName { get; set; } = null!;
    public DateTime? NewsAdded { get; set; }
    public int Team { get; set; }
    public string Form { get; set; } = null!;
}