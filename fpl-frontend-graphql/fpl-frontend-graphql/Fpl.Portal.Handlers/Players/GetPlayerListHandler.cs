using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Players;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Handlers.Players;

public class GetPlayerListHandler : IGetPlayerListHandler
{
    private readonly IGetBootstrapStaticFunctionCaller _getBootstrapStaticFunctionCaller;
    private readonly IMapper _mapper;
    
    public GetPlayerListHandler(IGetBootstrapStaticFunctionCaller getBootstrapStaticFunctionCaller,
        IMapper mapper)
    {
        _getBootstrapStaticFunctionCaller = getBootstrapStaticFunctionCaller;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<PlayerResult>> HandleAsync()
    {
        var globalFplData = await GetBootstrapStaticAsync();

        return globalFplData.Players
            .Select(BuildPlayer)
            .ToList();
        
        
        //Local Functions
        async Task<BootstrapStaticResponse> GetBootstrapStaticAsync() =>
            await _getBootstrapStaticFunctionCaller
                .ExecuteAsync()
                .ConfigureAwait(false);
        
        PlayerResult BuildPlayer(Player player) =>
            _mapper.Map<PlayerResult>(player);
    }
}