using System;
using System.Security.AccessControl;

namespace CricketScoreBoard.Models
{
    public class MatchData
    {
        public Guid MatchReference { get; set; }

        public ScoreCard HomeTeam { get; set; }

        public ScoreCard OpponentTeam { get; set; }
    }
}