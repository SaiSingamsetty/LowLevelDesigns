using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Models
{
    public class Match
    {
        public Innings HomeTeamInnings { get; set; }

        public Innings OpponentTeamInnings { get; set; }

        public int NoOfOvers { get; set; }

        public int NoOfPlayers { get; set; }

        public MatchStatus MatchStatus { get; set; }
    }

    public class Innings
    {
        public List<BattingStats> BattingStatistics { get; set; }

        public int BallsPlayed { get; set; }

        public int TotalScore { get; set; }

        public int Extras { get; set; }

        public bool IsInningsCompleted { get; set; }
    }

    public class BattingStats
    {
        public string PlayerId { get; set; }

        public bool IsOnCrease { get; set; }

        public bool IsOnStrike { get; set; }

        public PlayerStatus Status { get; set; }
        
        public int NoOfBalls { get; set; }

        public int Score { get; set; }

        public int Fours { get; set; }

        public int Sixes { get; set; }
    }

    public enum PlayerStatus
    {
        YetToBat,
        Batting,
        Out,
        RetiredHurt
    }

    public enum MatchStatus
    {
       YetToStart,
       InProgress,
       Completed,
       Cancelled,
       Postponed
    }
}
