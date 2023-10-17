using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Models;
using Fpl.Portal.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Services
{
    public class FunctionRequestService : FunctionRequestServiceBase, IFunctionRequestService
    {
        public FunctionRequestService(IHttpClientFactory httpClientFactory,
            ApiFunctionOptions apiFunctionOptions,
            JsonSerializerConfigOptions jsonSerializerConfigOptions)
            : base(httpClientFactory, apiFunctionOptions, jsonSerializerConfigOptions)
        { 
        }
    }
}
