using Fpl.Portal.Web.Repository.Repositories.Interfaces;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Abstractions.Websocket;
using GraphQL.Client.Http;

namespace Fpl.Portal.Web.Repository.Repositories;

public class FplGraphQlClient : GraphQLHttpClient, IFplGraphQlClient
{
    public FplGraphQlClient(string endPoint,
        IGraphQLWebsocketJsonSerializer serializer) 
        : base(endPoint, serializer)
    {
    }
}