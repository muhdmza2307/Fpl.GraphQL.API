using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Configuration.Options
{
    public class CompressionOptions
    {
        public CompressionOptions() => MimeTypes = new List<string>(); 
        
        /// <summary>
        /// Gets a list of MIME types to be compressed in addition to the default set used by ASP.NET Core. 
        /// </summary> 
        public List<string> MimeTypes { get; } }
    }
