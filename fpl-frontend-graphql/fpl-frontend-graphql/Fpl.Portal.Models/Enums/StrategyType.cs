using System.ComponentModel;

namespace Fpl.Portal.Models.Enums;

public enum StrategyType
{
    [Description("bboost")]BenchBoost,
    [Description("freehit")]FreeHit,
    [Description("wildcard")]WildCard,
    [Description("3xc")]TripleCapt
}