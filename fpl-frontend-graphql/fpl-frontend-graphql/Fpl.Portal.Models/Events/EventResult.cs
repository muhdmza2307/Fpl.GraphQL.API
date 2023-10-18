using Fpl.Portal.Models.Enums;

namespace Fpl.Portal.Models.Events;

public class EventResult
{
    public int EventId { get; set; }
    public string EventName { get; set; } = null!;
    public DateTime DeadlineTime { get; set; }
    public int EntryScoreAverage { get; set; }
    public bool IsFinished { get; set; }
    public bool IsDataChecked { get; set; }
    public int? HighestScoringEntry { get; set; }
    public long DeadlineTimePeriod { get; set; }
    public int GameOffsetUntilDeadline { get; set; }
    public int? HighestScore { get; set; }
    public bool IsPrevious { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsNext { get; set; }
    public bool IsCupLeaguesCreated { get; set; }
    public bool IsH2HMatchesCreated { get; set; }
    public int? TotalTransferMade  { get; set; }
    public PlayerInfo MostSelectedPlayer { get; set; } = null!;
    public PlayerInfo MostTransferredInPlayer { get; set; } = null!;
    public PlayerInfo MostCaptainedPlayer { get; set; } = null!;
    public PlayerInfo MostViceCaptainedPlayer { get; set; } = null!;
    public PlayerScoreInfo TopPlayer { get; set; } = null!;
    public IEnumerable<StrategyInfo> StrategyPlays { get; set; } = Enumerable.Empty<StrategyInfo>();
}

public class StrategyInfo
{
    public StrategyType StrategyTypeName { get; set; }
    public int TotalPlayed{ get; set; }
}

public class PlayerInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class PlayerScoreInfo : PlayerInfo
{
    public int Points { get; set; }
}