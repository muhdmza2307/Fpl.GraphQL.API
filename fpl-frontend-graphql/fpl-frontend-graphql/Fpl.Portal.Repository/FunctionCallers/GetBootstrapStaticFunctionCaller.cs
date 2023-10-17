using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Services.Interfaces;
using Fpl.Portal.Models.BootstrapStatic;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;

namespace Fpl.Portal.Repository.FunctionCallers
{
    public class GetBootstrapStaticFunctionCaller : GetFunctionCaller<BootstrapStaticResponse>,
        IGetBootstrapStaticFunctionCaller
    {
        public GetBootstrapStaticFunctionCaller(IFunctionRequestService functionRequestService,
            ApiEndPointsOptions endPointsOptions) 
            : base(functionRequestService, endPointsOptions)
        {
        }

        protected override string GetUri(ApiEndPointsOptions endPointsOptions)
            => endPointsOptions.BootstrapStatic;
    }
}
