using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Configuration.Options
{
    public class ApiEndPointsOptions
    {
        public string BootstrapStatic { get; set; } = null!;
        public string GetFixtures { get; set; } = null!;
    }
}
