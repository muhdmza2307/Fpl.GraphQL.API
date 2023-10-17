using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class Team
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }
        
        [JsonPropertyName("draw")]
        public long Draw { get; set; }
        
        [JsonPropertyName("form")]
        public object Form { get; set; } = null!;
        
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("loss")]
        public long Loss { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        
        [JsonPropertyName("played")]
        public long Played { get; set; }
        
        [JsonPropertyName("points")]
        public long Points { get; set; }
        
        [JsonPropertyName("position")]
        public long Position { get; set; }
        
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; } = null!;
        
        [JsonPropertyName("strength")]
        public long Strength { get; set; }
        
        [JsonPropertyName("team_division")]
        public long? TeamDivision { get; set; }
        
        [JsonPropertyName("unavailable")]
        public bool Unavailable { get; set; }
        
        [JsonPropertyName("win")]
        public long Win { get; set; }
        
        [JsonPropertyName("strength_overall_home")]
        public long StrengthOverallHome { get; set; }
        
        [JsonPropertyName("strength_overall_away")]
        public long StrengthOverallAway { get; set; }
        
        [JsonPropertyName("strength_attack_home")]
        public long StrengthAttackHome { get; set; }
        
        [JsonPropertyName("strength_attack_away")]
        public long StrengthAttackAway { get; set; }
        
        [JsonPropertyName("strength_defence_home")]
        public long StrengthDefenceHome { get; set; }
        
        [JsonPropertyName("strength_defence_away")]
        public long StrengthDefenceAway { get; set; }
        
        [JsonPropertyName("pulse_id")]
        public int PulseId { get; set; }
    }

}
