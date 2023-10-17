using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class TopElementInfo
    {
        [JsonPropertyName("id")]
        public int Id {  get; set; }
        
        [JsonPropertyName("points")]
        public int Points { get; set; }
    }
}
