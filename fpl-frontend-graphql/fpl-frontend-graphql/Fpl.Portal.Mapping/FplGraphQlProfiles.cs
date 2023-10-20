using AutoMapper;
using Fpl.Portal.Mapping.Profiles;

namespace Fpl.Portal.Mapping;

public static class FplGraphQlProfiles
{
    public static readonly IEnumerable<Profile> Profiles = new List<Profile>
    {
        new FixturesResultMappingProfile(),
        new EventResultMappingProfile(),
        new TeamResultMappingProfile(),
        new PlayerResultMappingProfile()
    };
}