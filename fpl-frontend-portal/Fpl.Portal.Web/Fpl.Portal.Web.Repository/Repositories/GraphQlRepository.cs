using Fpl.Portal.Web.Repository.Repositories.Interfaces;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace Fpl.Portal.Web.Repository.Repositories;

public class GraphQlRepository : IGraphQlRepository
{
    private readonly IGraphQLClient _client;

    protected GraphQlRepository(IGraphQLClient client)
    {
        _client = client;
    }
    
    public async Task<TResult> QueryAsync<TResponse, TResult>(IGraphQlQuery<TResponse, TResult> query)
    {
        try
        {
            var response = await Query(Request());
            //ValidateResponse(response);
            return query.ExtractResult(response.Data);
        }
        catch (HttpRequestException e)
        {
            //throw new GraphQlCallException(e);
            throw;
        }
        
        
        // Local Functions
        GraphQLRequest Request() => new()
        {
            Query = query.Query,
            Variables = query.Variables,
        };

        async Task<GraphQLResponse<TResponse>> Query(GraphQLRequest request)
            => await _client.SendQueryAsync<TResponse>(request).ConfigureAwait(false);
    }
    
    /*private void ValidateResponse<TResponse>(GraphQLResponse<TResponse> response)
    {
        if (response.Errors?.Length > 0)
            throw new GraphQlResponseException(response.Errors.Select(x => x.Message));
    }*/
}