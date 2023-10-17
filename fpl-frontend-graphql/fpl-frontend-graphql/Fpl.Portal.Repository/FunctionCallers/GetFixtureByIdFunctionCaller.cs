using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Services.Interfaces;
using Fpl.Portal.Models.Fixtures;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Repository.FunctionCallers;

public class GetFixtureByIdFunctionCaller : GetFunctionCaller<IEnumerable<FixtureQueryResponse>, GetFixturesInput>,
    IGetFixtureFunctionCallerById
{
    public GetFixtureByIdFunctionCaller(IFunctionRequestService functionRequestService,
        ApiEndPointsOptions endPointsOptions)
        : base(functionRequestService, endPointsOptions)
    {
    }

    protected override string GetUri(ApiEndPointsOptions endPointsOptions, GetFixturesInput request)
        => request.EventId.HasValue
            ? $"{endPointsOptions.GetFixtures}?event={request.EventId}"
            : endPointsOptions.GetFixtures;
}