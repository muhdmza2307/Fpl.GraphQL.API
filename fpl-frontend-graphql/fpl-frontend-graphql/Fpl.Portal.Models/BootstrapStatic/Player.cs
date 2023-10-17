using System.Text.Json.Serialization;

namespace Fpl.Portal.Models.BootstrapStatic
{
    public class Player
    {
        [JsonPropertyName("chance_of_playing_this_round")]
        public int? ChanceOfPlayingThisRound { get; set; }

        [JsonPropertyName("chance_of_playing_next_round")]
        public int? ChanceOfPlayingNextRound { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("cost_change_event")]
        public int CostChangeEvent { get; set; }

        [JsonPropertyName("cost_change_event_fall")]
        public int CostChangeEventFall { get; set; }

        [JsonPropertyName("cost_change_start")]
        public int CostChangeStart { get; set; }

        [JsonPropertyName("cost_change_start_fall")]
        public int CostChangeStartFall { get; set; }

        [JsonPropertyName("dreamteam_count")]
        public int DreamTeamCount { get; set; }

        [JsonPropertyName("element_type")]
        public int ElementType { get; set; }

        [JsonPropertyName("ep_next")]
        public string EpNext { get; set; } = null!;

        [JsonPropertyName("ep_this")]
        public string EpThis { get; set; } = null!;

        [JsonPropertyName("event_points")]
        public int EventPoints { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = null!;

        [JsonPropertyName("form")]
        public string Form { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("in_dreamteam")]
        public bool InDreamTeam { get; set; }

        [JsonPropertyName("news")]
        public string News { get; set; } = null!;

        [JsonPropertyName("news_added")]
        public DateTime? NewsAdded { get; set; }

        [JsonPropertyName("now_cost")]
        public int NowCost { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; } = null!;

        [JsonPropertyName("points_per_game")]
        public string PointsPerGame { get; set; } = null!;

        [JsonPropertyName("second_name")]
        public string SecondName { get; set; } = null!;

        [JsonPropertyName("selected_by_percent")]
        public string SelectedByPercent { get; set; } = null!;

        [JsonPropertyName("special")]
        public bool Special { get; set; }

        [JsonPropertyName("squad_number")]
        public int? SquadNumber { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        [JsonPropertyName("team")]
        public int Team { get; set; }

        [JsonPropertyName("team_code")]
        public int TeamCode { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }

        [JsonPropertyName("transfers_in")]
        public int TransfersIn { get; set; }

        [JsonPropertyName("transfers_in_event")]
        public int TransfersInEvent { get; set; }

        [JsonPropertyName("transfers_out")]
        public int TransfersOut { get; set; }

        [JsonPropertyName("transfers_out_event")]
        public int TransfersOutEvent { get; set; }

        [JsonPropertyName("value_form")]
        public string ValueForm { get; set; } = null!;

        [JsonPropertyName("value_season")]
        public string ValueSeason { get; set; } = null!;

        [JsonPropertyName("web_name")]
        public string WebName { get; set; } = null!;

        [JsonPropertyName("minutes")]
        public int Minutes { get; set; }

        [JsonPropertyName("goals_scored")]
        public int GoalsScored { get; set; }

        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        [JsonPropertyName("clean_sheets")]
        public int CleanSheets { get; set; }

        [JsonPropertyName("goals_conceded")]
        public int GoalsConceded { get; set; }

        [JsonPropertyName("own_goals")]
        public int OwnGoals { get; set; }

        [JsonPropertyName("penalties_saved")]
        public int PenaltiesSaved { get; set; }

        [JsonPropertyName("penalties_missed")]
        public int PenaltiesMissed { get; set; }

        [JsonPropertyName("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonPropertyName("red_cards")]
        public int RedCards { get; set; }

        [JsonPropertyName("saves")]
        public int Saves { get; set; }

        [JsonPropertyName("bonus")]
        public int Bonus { get; set; }

        [JsonPropertyName("bps")]
        public int Bps { get; set; }

        [JsonPropertyName("influence")]
        public string Influence { get; set; } = null!;

        [JsonPropertyName("creativity")]
        public string Creativity { get; set; } = null!;

        [JsonPropertyName("threat")]
        public string Threat { get; set; } = null!;

        [JsonPropertyName("ict_index")]
        public string IctIndex { get; set; } = null!;

        [JsonPropertyName("starts")]
        public int Starts { get; set; }

        [JsonPropertyName("expected_goals")]
        public string ExpectedGoals { get; set; } = null!;

        [JsonPropertyName("expected_assists")]
        public string ExpectedAssists { get; set; } = null!;

        [JsonPropertyName("expected_goal_involvements")]
        public string ExpectedGoalInvolvements { get; set; } = null!;

        [JsonPropertyName("expected_goals_conceded")]
        public string ExpectedGoalsConceded { get; set; } = null!;

        [JsonPropertyName("influence_rank")]
        public int InfluenceRank { get; set; }

        [JsonPropertyName("influence_rank_type")]
        public int InfluenceRankType { get; set; }

        [JsonPropertyName("creativity_rank")]
        public int CreativityRank { get; set; }

        [JsonPropertyName("creativity_rank_type")]
        public int CreativityRankType { get; set; }

        [JsonPropertyName("threat_rank")]
        public int ThreatRank { get; set; }

        [JsonPropertyName("threat_rank_type")]
        public int ThreatRankType { get; set; }

        [JsonPropertyName("ict_index_rank")]
        public int IctIndexRank { get; set; }

        [JsonPropertyName("ict_index_rank_type")]
        public int IctIndexRankType { get; set; }

        [JsonPropertyName("corners_and_indirect_freekicks_order")]
        public int? CornersAndIndirectFreeKicksOrder { get; set; }

        [JsonPropertyName("corners_and_indirect_freekicks_text")]
        public string CornersAndIndirectFreeKicksText { get; set; } = null!;

        [JsonPropertyName("direct_freekicks_order")]
        public int? DirectFreeKicksOrder { get; set; }

        [JsonPropertyName("direct_freekicks_text")]
        public string DirectFreeKicksText { get; set; } = null!;

        [JsonPropertyName("penalties_order")]
        public int? PenaltiesOrder { get; set; }

        [JsonPropertyName("penalties_text")]
        public string PenaltiesText { get; set; } = null!;

        [JsonPropertyName("expected_goals_per_90")]
        public double ExpectedGoalsPer90 { get; set; }

        [JsonPropertyName("saves_per_90")]
        public double SavesPer90 { get; set; }

        [JsonPropertyName("expected_assists_per_90")]
        public double ExpectedAssistsPer90 { get; set; }

        [JsonPropertyName("expected_goal_involvements_per_90")]
        public double ExpectedGoalInvolvementsPer90 { get; set; }

        [JsonPropertyName("expected_goals_conceded_per_90")]
        public double ExpectedGoalsConcededPer90 { get; set; }

        [JsonPropertyName("goals_conceded_per_90")]
        public double GoalsConcededPer90 { get; set; }

        [JsonPropertyName("now_cost_rank")]
        public int NowCostRank { get; set; }

        [JsonPropertyName("now_cost_rank_type")]
        public int NowCostRankType { get; set; }

        [JsonPropertyName("form_rank")]
        public int FormRank { get; set; }

        [JsonPropertyName("form_rank_type")]
        public int FormRankType { get; set; }

        [JsonPropertyName("points_per_game_rank")]
        public int PointsPerGameRank { get; set; }

        [JsonPropertyName("points_per_game_rank_type")]
        public int PointsPerGameRankType { get; set; }

        [JsonPropertyName("selected_rank")]
        public int SelectedRank { get; set; }

        [JsonPropertyName("selected_rank_type")]
        public int SelectedRankType { get; set; }

        [JsonPropertyName("starts_per_90")]
        public double StartsPer90 { get; set; }

        [JsonPropertyName("clean_sheets_per_90")]
        public double CleanSheetsPer90 { get; set; }
    }
}
