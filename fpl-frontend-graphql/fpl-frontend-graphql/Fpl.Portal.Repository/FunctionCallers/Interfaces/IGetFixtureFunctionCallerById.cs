using Fpl.Portal.Models.Fixtures;

namespace Fpl.Portal.Repository.FunctionCallers.Interfaces;

public interface IGetFixturesByEventIdFunctionCallerById :
    IGetFunctionCaller<IEnumerable<FixtureQueryResponse>, GetFixturesInput>
{
    
}