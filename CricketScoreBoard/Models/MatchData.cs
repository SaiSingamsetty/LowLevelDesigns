using System;

namespace CricketScoreBoard.Models
{
    public class MatchData
    {
        public Guid MatchReference { get; set; }

        public ScoreCard TeamOneCard { get; set; }

        public ScoreCard TeamTwoCard { get; set; }
    }
}