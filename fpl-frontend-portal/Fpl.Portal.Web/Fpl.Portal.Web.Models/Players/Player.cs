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
    public string TeamName { get; set; } = null!;
    public string Form { get; set; } = null!;
    public int GoalsScored { get; set; }
    public int Assists { get; set; }
    public int CleanSheets { get; set; }
    public int GoalsConceded { get; set; }
}