using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Fixtures;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Handlers.Fixtures;

public class GetFixturesByEventIdHandler : IGetFixturesByEventIdHandler
{
    private readonly IGetBootstrapStaticFunctionCaller _getBootstrapStaticFunctionCaller;
    private readonly IGetFixturesByEventIdFunctionCallerById _getFixturesByEventIdFunctionCallerById;
    private readonly IMapper _mapper;

    public GetFixturesByEventIdHandler(IGetBootstrapStaticFunctionCaller getBootstrapStaticFunctionCaller,
        IGetFixturesByEventIdFunctionCallerById getFixturesByEventIdFunctionCallerById,
        IMapper mapper)
    {
        _getBootstrapStaticFunctionCaller = getBootstrapStaticFunctionCaller;
        _getFixturesByEventIdFunctionCallerById = getFixturesByEventIdFunctionCallerById;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FixturesResult>> HandleAsync(GetFixturesInput request)
    {
        var globalFplData = await GetBootstrapStaticAsync();
        var fixtures = (await GetFixturesAsync()).ToArray();

        return fixtures
            .Select(BuildFixture)
            .ToList();

        
        //Local Functions
        async Task<IEnumerable<FixtureQueryResponse>> GetFixturesAsync() =>
            await _getFixturesByEventIdFunctionCallerById
                .ExecuteAsync(request)
                .ConfigureAwait(false);

        FixturesResult BuildFixture(FixtureQueryResponse fixtureQueryResponse) =>
            _mapper.Map<FixturesResult>(fixtureQueryResponse, 
                CreateMappingOptions(globalFplData, fixtureQueryResponse));
    }
    
    private static Action<IMappingOperationOptions> CreateMappingOptions(BootstrapStaticResponse globalFplData,
        FixtureQueryResponse fixtures)
    {
        return opt =>
        {
            opt.Items["AwayTeam"] = FindTeamFromGlobal(fixtures.TeamA);
            opt.Items["HomeTeam"] = FindTeamFromGlobal(fixtures.TeamH);
            opt.Items["Players"] = globalFplData.Players;
        };
        
        
        //Local Function
        Team FindTeamFromGlobal(int teamId) =>
            globalFplData.Teams.ToList()
                .Find(t => t.Id == teamId)!;
    }
    
    private async Task<BootstrapStaticResponse> GetBootstrapStaticAsync() =>
        await _getBootstrapStaticFunctionCaller
            .ExecuteAsync()
            .ConfigureAwait(false);
}