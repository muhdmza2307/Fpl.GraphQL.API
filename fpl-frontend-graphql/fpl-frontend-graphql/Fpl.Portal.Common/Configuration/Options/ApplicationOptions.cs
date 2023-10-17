using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Configuration.Options
{
    public class ApplicationOptions
    {
        public ApplicationOptions() => CacheProfiles = new CacheProfileOptions();
        public CacheProfileOptions CacheProfiles { get; }
        public CompressionOptions Compression { get; set; } = default!;
        public GraphQLOptions GraphQL { get; set; } = default!;
        public KestrelServerOptions Kestrel { get; set; } = default!;
        public ForwardedHeadersOptions ForwardedHeaders { get; set; } = default!;
    }
}
