using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Repository.FunctionCallers.Interfaces;

public interface IGetFixtureFunctionCallerById : IGetFunctionCaller<IEnumerable<FixtureQueryResponse>, GetFixturesInput>
{
    
}