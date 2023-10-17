using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Models;
using Fpl.Portal.Common.Services.Interfaces;
using Fpl.Portal.Common.Extensions;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using Fpl.Portal.Common.Exceptions;

namespace Fpl.Portal.Repository.FunctionCallers
{
    public abstract class GetFunctionCaller<TResponse, TRequest> : IGetFunctionCaller<TResponse, TRequest>
{
    private readonly IFunctionRequestService _functionRequestService;
    private readonly ApiEndPointsOptions _endPointsOptions;

    protected GetFunctionCaller(IFunctionRequestService functionRequestService, ApiEndPointsOptions endPointsOptions)
    {
        _functionRequestService = functionRequestService;
        _endPointsOptions = endPointsOptions;
    }

    public async Task<TResponse> ExecuteAsync(TRequest request)
    {
        var functionRequestResponse = await CallFunctionAsync(request).ConfigureAwait(false);

        return !functionRequestResponse.IsValidResponseAndHasData()
            ? HandleInvalidResponse(functionRequestResponse, request)
            : functionRequestResponse.Data!;
    }

    private async Task<FunctionRequestResponse<TResponse>> CallFunctionAsync(TRequest request)
    {
        var uri = GetUri(_endPointsOptions, request);
        return await _functionRequestService.GetAsync<TResponse>(uri).ConfigureAwait(false);
    }

    protected abstract string GetUri(ApiEndPointsOptions endPointsOptions, TRequest request);

    protected virtual TResponse HandleInvalidResponse(FunctionRequestResponse<TResponse> functionRequestResponse, TRequest request)
    {
        var uri = GetUri(_endPointsOptions, request);
        var httpStatusCode = functionRequestResponse.HttpStatusCode;
        var errorMessage = functionRequestResponse.ErrorMessage ?? "Data is not found";
        throw new InvalidFunctionResponseException(uri, httpStatusCode, errorMessage);
    }
}

public abstract class GetFunctionCaller<TResponse> : IGetFunctionCaller<TResponse>
{
    private readonly IFunctionRequestService _functionRequestService;
    private readonly ApiEndPointsOptions _endPointsOptions;

    protected GetFunctionCaller(IFunctionRequestService functionRequestService, ApiEndPointsOptions endPointsOptions)
    {
        _functionRequestService = functionRequestService;
        _endPointsOptions = endPointsOptions;
    }

    public async Task<TResponse> ExecuteAsync()
    {
        var functionRequestResponse = await CallFunctionAsync().ConfigureAwait(false);

        return !functionRequestResponse.IsValidResponseAndHasData()
            ? HandleInvalidResponse(functionRequestResponse)
            : functionRequestResponse.Data!;
    }

    private async Task<FunctionRequestResponse<TResponse>> CallFunctionAsync()
    {
        var uri = GetUri(_endPointsOptions);
        return await _functionRequestService.GetAsync<TResponse>(uri).ConfigureAwait(false);
    }

    protected abstract string GetUri(ApiEndPointsOptions endPointsOptions);

    protected virtual TResponse HandleInvalidResponse(FunctionRequestResponse<TResponse> functionRequestResponse)
    {
        var uri = GetUri(_endPointsOptions);
        var httpStatusCode = functionRequestResponse.HttpStatusCode;
        var errorMessage = functionRequestResponse.ErrorMessage ?? "Data is not found";
        throw new InvalidFunctionResponseException(uri, httpStatusCode, errorMessage);
    }
}
}
