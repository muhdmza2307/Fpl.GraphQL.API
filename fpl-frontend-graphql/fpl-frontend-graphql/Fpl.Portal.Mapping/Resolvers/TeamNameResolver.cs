using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Players;

namespace Fpl.Portal.Mapping.Resolvers;

public class TeamNameResolver : IValueResolver<Player, PlayerResult, string>
{
    public string Resolve(Player source,
        PlayerResult destination,
        string destMember,
        ResolutionContext context)
    {
        var teams = (IEnumerable<Team>)context.Options.Items["Teams"];
        return context.Mapper.Map<string>(GetTeamName());
        
        
        //Local Function
        string GetTeamName() =>
            teams
                .Where(team => team.Id == source.Team)
                .Select(team => team.Name)
                .FirstOrDefault()!;
    }
        
}