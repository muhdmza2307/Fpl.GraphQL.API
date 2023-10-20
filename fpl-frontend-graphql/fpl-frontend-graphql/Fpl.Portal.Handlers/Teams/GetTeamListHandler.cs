using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Teams;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Handlers.Teams;

public class GetTeamListHandler : IGetTeamListHandler
{
    private readonly IGetBootstrapStaticFunctionCaller _getBootstrapStaticFunctionCaller;
    private readonly IMapper _mapper;

    public GetTeamListHandler(IGetBootstrapStaticFunctionCaller getBootstrapStaticFunctionCaller,
        IMapper mapper)
    {
        _getBootstrapStaticFunctionCaller = getBootstrapStaticFunctionCaller;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamResult>> HandleAsync()
    {
        var globalFplData = await GetBootstrapStaticAsync();

        return globalFplData.Teams
            .Select(BuildTeam)
            .ToList();
        
        
        //Local Functions
        async Task<BootstrapStaticResponse> GetBootstrapStaticAsync() =>
            await _getBootstrapStaticFunctionCaller
                .ExecuteAsync()
                .ConfigureAwait(false);
        
        TeamResult BuildTeam(Team team) =>
            _mapper.Map<TeamResult>(team);
    }
}