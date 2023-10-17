using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Repository.FunctionCallers.Interfaces
{
    public interface IGetFunctionCaller<TResponse, in TRequest>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
    
    public interface IGetFunctionCaller<TResponse>
    {
        Task<TResponse> ExecuteAsync();
    }
}
