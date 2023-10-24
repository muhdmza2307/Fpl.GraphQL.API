namespace Fpl.Portal.Web.Repository.Repositories;

public interface IGraphQlQuery<in TResponse, out TResult>
{
    string Query { get; }

    object? Variables { get; }

    TResult ExtractResult(TResponse response);
}