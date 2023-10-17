using Fpl.Portal.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Extensions
{
    public static class FunctionRequestResponseExtensions
    {
        public static bool IsValidResponseAndHasData<T>(this FunctionRequestResponse<T> response)
            => response.IsValidResponse && response.Data != null;
    }
}
