using System.Text.Json.Serialization;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class Event
    {
        [JsonPropertyName("id")]
        public int EventId { get; set; }

        [JsonPropertyName("name")]
        public string EventName { get; set; } = null!;

        [JsonPropertyName("deadline_time")]
        public DateTime DeadlineTime { get; set; }

        [JsonPropertyName("average_entry_score")]
        public int EntryScoreAverage { get; set; }

        [JsonPropertyName("finished")]
        public bool IsFinished { get; set; }

        [JsonPropertyName("data_checked")]
        public bool IsDataChecked { get; set; }

        [JsonPropertyName("highest_scoring_entry")]
        public int? HighestScoringEntry { get; set; }

        [JsonPropertyName("deadline_time_epoch")]
        public long DeadlineTimePeriod { get; set; }

        [JsonPropertyName("deadline_time_game_offset")]
        public int GameOffsetUntilDeadline { get; set; }

        [JsonPropertyName("highest_score")]
        public int? HighestScore { get; set; }

        [JsonPropertyName("is_previous")]
        public bool IsPrevious { get; set; }

        [JsonPropertyName("is_current")]
        public bool IsCurrent { get; set; }

        [JsonPropertyName("is_next")]
        public bool IsNext { get; set; }

        [JsonPropertyName("cup_leagues_created")]
        public bool IsCupLeaguesCreated { get; set; }

        [JsonPropertyName("h2h_ko_matches_created")]
        public bool IsH2HMatchesCreated { get; set; }

        [JsonPropertyName("chip_plays")]
        public IEnumerable<ChipPlay> ChipPlays { get; set; } = Enumerable.Empty<ChipPlay>();

        [JsonPropertyName("most_selected")]
        public int? MostSelected { get; set; }

        [JsonPropertyName("most_transferred_in")]
        public int? MostTransferredIn { get; set; }

        [JsonPropertyName("top_element")]
        public int? TopElement { get; set; }

        [JsonPropertyName("top_element_info")]
        public TopElementInfo? TopElementInfo { get; set; }

        [JsonPropertyName("transfers_made")]
        public int? TotalTransferMade { get; set; }

        [JsonPropertyName("most_captained")]
        public int? MostCaptained { get; set; }

        [JsonPropertyName("most_vice_captained")]
        public int? MostViceCaptained { get; set; }
    }

}
