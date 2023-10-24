namespace Fpl.Portal.Web.Models.FplGraphQlResponse;

public class FplGraphQlResponse<TGraphQlDataResponse>
    where TGraphQlDataResponse : IGraphQlDataResponse
{
    public IEnumerable<TGraphQlDataResponse>? PlayerList { get; set; }
    
    public IEnumerable<TGraphQlDataResponse>? TeamList { get; set; }
}