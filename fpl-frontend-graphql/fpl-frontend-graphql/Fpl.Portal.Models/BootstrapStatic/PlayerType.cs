using System.Text.Json.Serialization;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class PlayerType
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("plural_name")]
        public string PluralName { get; set; } = null!;

        [JsonPropertyName("plural_name_short")]
        public string PluralNameShort { get; set; } = null!;

        [JsonPropertyName("singular_name")]
        public string SingularName { get; set; } = null!;

        [JsonPropertyName("singular_name_short")]
        public string SingularNameShort { get; set; } = null!;

        [JsonPropertyName("squad_select")]
        public int SquadSelect { get; set; }

        [JsonPropertyName("squad_min_play")]
        public int SquadMinPlay { get; set; }

        [JsonPropertyName("squad_max_play")]
        public int SquadMaxPlay { get; set; }

        [JsonPropertyName("ui_shirt_specific")]
        public bool UiShirtSpecific { get; set; }

        [JsonPropertyName("sub_positions_locked")]
        public IEnumerable<int> SubPositionsLocked { get; set; } = Enumerable.Empty<int>();

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }
    }
}
