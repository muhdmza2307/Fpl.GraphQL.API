using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Models
{
    public class FunctionRequestResponse<TResponse>
    {
        public TResponse? Data { get; init; }
        public HttpStatusCode? HttpStatusCode { get; init; }
        public bool IsValidResponse => HttpStatusCode.HasValue &&
            (int)HttpStatusCode.Value >= 200
            && (int)HttpStatusCode.Value <= 299; 
        public string? ErrorMessage { get; init; }
    }
}
