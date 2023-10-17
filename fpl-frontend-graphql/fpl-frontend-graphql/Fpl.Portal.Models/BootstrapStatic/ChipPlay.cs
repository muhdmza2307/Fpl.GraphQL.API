using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class ChipPlay
    {
        [JsonPropertyName("chip_name")]
        public string ChipName { get; set; } = null!;
        
        [JsonPropertyName("num_played")]
        public int NumPlayed { get; set; }
    }
}
