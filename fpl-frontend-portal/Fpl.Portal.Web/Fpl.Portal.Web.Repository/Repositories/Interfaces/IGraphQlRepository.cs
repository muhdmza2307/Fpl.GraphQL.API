namespace Fpl.Portal.Web.Repository.Repositories.Interfaces;

public interface IGraphQlRepository
{
    Task<TResult> QueryAsync<TResponse, TResult>(IGraphQlQuery<TResponse, TResult> query);
}