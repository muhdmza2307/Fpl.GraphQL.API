using AutoMapper;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Models.Events;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Handlers.Events;

public class GetLatestEventHandler : IGetLatestEventHandler
{
    private readonly IGetBootstrapStaticFunctionCaller _getBootstrapStaticFunctionCaller;
    private readonly IMapper _mapper;

    public GetLatestEventHandler(IGetBootstrapStaticFunctionCaller getBootstrapStaticFunctionCaller,
        IMapper mapper)
    {
        _getBootstrapStaticFunctionCaller = getBootstrapStaticFunctionCaller;
        _mapper = mapper;
    }

    public async Task<EventResult> HandleAsync()
    {
        var globalFplData = await GetBootstrapStaticAsync();

        var gameWeek = globalFplData.Events
            .LastOrDefault(game => game.IsFinished);

        return gameWeek != null ?
            BuildFixture(gameWeek)
            : new EventResult();
        
        
        //Local Function
        EventResult BuildFixture(Event game) =>
            _mapper.Map<EventResult>(game, CreateMappingOptions(globalFplData,
                gameWeek));
    }
    
    private static Action<IMappingOperationOptions> CreateMappingOptions(BootstrapStaticResponse globalFplData,
        Event game)
    {
        return opt =>
        {
            opt.Items["MostSelectedPlayer"] = FindPlayerFromGlobal(game.MostSelected ?? 0);
            opt.Items["MostTransferredInPlayer"] = FindPlayerFromGlobal(game.MostTransferredIn ?? 0);
            opt.Items["TopPlayer"] = FindPlayerFromGlobal(game.TopElement ?? 0);
            opt.Items["MostCaptainedPlayer"] = FindPlayerFromGlobal(game.MostCaptained ?? 0);
            opt.Items["MostViceCaptainedPlayer"] = FindPlayerFromGlobal(game.MostViceCaptained ?? 0);
            opt.Items["TopPlayer"] = FindPlayerFromGlobal(game.TopElement ?? 0);
            opt.Items["TopPlayerPoints"] = game.TopElementInfo?.Points ?? 0;
        };
        
        
        //Local Function
        Player FindPlayerFromGlobal(int playerId) =>
            globalFplData.Players.ToList()
                .Find(t => t.Id == playerId)!;
    }
    
    private async Task<BootstrapStaticResponse> GetBootstrapStaticAsync() =>
        await _getBootstrapStaticFunctionCaller
            .ExecuteAsync()
            .ConfigureAwait(false);
}