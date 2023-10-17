using System.ComponentModel;

namespace Fpl.Portal.Models.Enums;

public enum StatIdentifier
{
    [Description("goals_scored")]GoalsScored,
    [Description("assists")]Assists,
    [Description("own_goals")]OwnGoals,
    [Description("penalties_saved")]PenaltiesSaved,
    [Description("penalties_missed")]PenaltiesMissed,
    [Description("yellow_cards")]YellowCards,
    [Description("red_cards")]RedCards,
    [Description("saves")]Saves,
    [Description("bonus")]Bonus,
    [Description("bps")]Bps
}