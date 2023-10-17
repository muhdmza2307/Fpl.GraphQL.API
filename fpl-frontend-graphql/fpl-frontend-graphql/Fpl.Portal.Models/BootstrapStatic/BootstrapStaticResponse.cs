using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class BootstrapStaticResponse
    {
        [JsonPropertyName("events")]
        public IEnumerable<Event> Events { get; set; } = null!;
        
        [JsonPropertyName("game_settings")]
        public GameSettings GameSettings { get; set; } = null!;
        
        [JsonPropertyName("phases")]
        public IEnumerable<Phase> Phases { get; set; } = null!;
        
        [JsonPropertyName("teams")]
        public IEnumerable<Team> Teams { get; set; } = null!;
        
        [JsonPropertyName("total_players")]
        public int TotalPlayers  { get; set; }
        
        [JsonPropertyName("elements")]
        public IEnumerable<Player> Players  { get; set; } = null!;
        
        [JsonPropertyName("element_stats")]
        public IEnumerable<ElementStat> StatsOptions { get; set; } = null!;
        
        [JsonPropertyName("element_types")]
        public IEnumerable<PlayerType> PlayerTypes  { get; set; } = null!;
    }
}
