using System.Text.Json.Serialization;

namespace Fpl.Portal.Models.Fixtures;

public class FixtureQueryResponse
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("event")]
    public int? Event { get; set; }

    [JsonPropertyName("finished")]
    public bool IsFinished { get; set; }

    [JsonPropertyName("finished_provisional")]
    public bool IsEventFinishedProvisional { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("kickoff_time")]
    public DateTime? KickoffTime { get; set; }

    [JsonPropertyName("minutes")]
    public int Minutes { get; set; }

    [JsonPropertyName("provisional_start_time")]
    public bool IsProvisionalStartTime { get; set; }

    [JsonPropertyName("started")]
    public bool? IsStarted { get; set; }

    [JsonPropertyName("team_a")]
    public int TeamA { get; set; }

    [JsonPropertyName("team_a_score")]
    public int? AwayTeamScore { get; set; }

    [JsonPropertyName("team_h")]
    public int TeamH { get; set; }

    [JsonPropertyName("team_h_score")]
    public int? HomeTeamScore { get; set; }

    [JsonPropertyName("stats")]
    public IEnumerable<FixtureStatQueryResponse> Stats { get; set; } = Enumerable.Empty<FixtureStatQueryResponse>();

    [JsonPropertyName("team_h_difficulty")]
    public int HomeDifficultyLevel { get; set; }

    [JsonPropertyName("team_a_difficulty")]
    public int AwayDifficultyLevel { get; set; }

    [JsonPropertyName("pulse_id")]
    public int PulseId { get; set; }
}

public class FixtureStatQueryResponse
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = null!;

    [JsonPropertyName("a")] 
    public IEnumerable<FixtureStatValueQueryResponse> AwayStats { get; set; } = Enumerable.Empty<FixtureStatValueQueryResponse>();

    [JsonPropertyName("h")] 
    public IEnumerable<FixtureStatValueQueryResponse> HomeStats { get; set; } = Enumerable.Empty<FixtureStatValueQueryResponse>();
}

public class FixtureStatValueQueryResponse
{
    [JsonPropertyName("element")]
    public int Element { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }
}