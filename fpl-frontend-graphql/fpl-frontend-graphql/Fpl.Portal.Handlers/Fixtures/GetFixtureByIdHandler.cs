using AutoMapper;
using Fpl.Portal.Common.Extensions;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Fixtures;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using Newtonsoft.Json;

namespace Fpl.Portal.Handlers.Fixtures;

public class GetFixtureByIdHandler : IGetFixtureByIdHandler
{
    private readonly IGetBootstrapStaticFunctionCaller _getBootstrapStaticFunctionCaller;
    private readonly IGetFixtureFunctionCallerById _getFixtureByIdFunctionCaller;
    private readonly IMapper _mapper;

    public GetFixtureByIdHandler(IGetBootstrapStaticFunctionCaller getBootstrapStaticFunctionCaller,
        IGetFixtureFunctionCallerById getFixtureByIdFunctionCaller,
        IMapper mapper)
    {
        _getBootstrapStaticFunctionCaller = getBootstrapStaticFunctionCaller;
        _getFixtureByIdFunctionCaller = getFixtureByIdFunctionCaller;
        _mapper = mapper;
    }

    public async Task<FixturesResult> HandleAsync(GetFixturesInput request)
    {
        var globalFplData = await GetBootstrapStaticAsync();
        var fixtures = (await GetFixturesAsync()).ToArray();

        return fixtures.Any() ? BuildFixture() : new FixturesResult();

        
        //Local Functions
        async Task<IEnumerable<FixtureQueryResponse>> GetFixturesAsync() =>
            await _getFixtureByIdFunctionCaller
                .ExecuteAsync(request)
                .ConfigureAwait(false);

        FixturesResult BuildFixture() =>
            _mapper.Map<FixturesResult>(fixtures.FirstOrDefault(), 
                CreateMappingOptions(globalFplData, fixtures.FirstOrDefault()!));
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
            globalFplData!.Teams.ToList()
                .Find(t => t.Id == teamId)!;
    }
    
    private async Task<BootstrapStaticResponse> GetBootstrapStaticAsync() =>
        await _getBootstrapStaticFunctionCaller
            .ExecuteAsync()
            .ConfigureAwait(false);
}