using HotChocolate.Execution.Options;
using HotChocolate.Types.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Configuration.Options
{
    public class GraphQLOptions
    {
        public int MaxAllowedExecutionDepth { get; set; }
        public PagingOptions Paging {  get; set; }
        public RequestExecutorOptions Request { get; set; } = default!;
    }
}
