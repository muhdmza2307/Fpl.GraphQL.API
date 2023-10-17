using Fpl.Portal.Models.Enums;

namespace Fpl.Portal.Models.Fixtures;

public class FixturesResult
{
    public int FixtureCode { get; set; }
    public int EventId { get; set; }
    public bool IsEventFinished { get; set; }
    public bool IsEventFinishedProvisional { get; set; }
    public int FixtureId { get; set; }
    public DateTime KickOffDateTime { get; set; }
    public int Minutes { get; set; }
    public bool IsProvisionalStartTime { get; set; }
    public bool IsStarted { get; set; }
    public TeamInfo AwayTeam { get; set; } = null!;
    public int AwayTeamScore { get; set; }
    public TeamInfo HomeTeam { get; set; } = null!;
    public int HomeTeamScore { get; set; }
    public int PulseId { get; set; }
    public int AwayDifficultyLevel { get; set; }
    public int HomeDifficultyLevel { get; set; }
    public IEnumerable<Stat> Stats { get; set; } = Enumerable.Empty<Stat>();
}

public class TeamInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class Stat
{
    public StatIdentifier StatIdentifierName { get; set; }
    public IEnumerable<StatInformation> AwayStatInfo { get; set; } = Enumerable.Empty<StatInformation>();
    public IEnumerable<StatInformation> HomeStatInfo { get; set; } = Enumerable.Empty<StatInformation>();
}

public class StatInformation
{
    public int Value { get; set; }
    public Label Label { get; set; } = null!;
}

public class Label
{
    public int LabelId { get; set; }
    public string LabelName { get; set; } = null!;
}

