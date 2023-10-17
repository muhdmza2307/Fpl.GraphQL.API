using Fpl.Portal.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Services.Interfaces
{
    public interface IFunctionRequestService
    {
        Task<FunctionRequestResponse<TResponse>> GetAsync<TResponse>(string url);
    }
}
