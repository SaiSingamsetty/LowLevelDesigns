using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Models
{
    public class Match
    {
        public Guid MatchId { get; set; }

        public int NoOfOvers { get; set; }

        public int NoOfPlayers { get; set; }

        public int TeamOneId { get; set; }

        public int TeamTwoId { get; set; }
    }

    public class MatchData
    {
        public Guid MatchReference { get; set; }

        public ScoreCard TeamOneCard { get; set; }

        public ScoreCard TeamTwoCard { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Team
    {
        public int TeamId { get; set; }

        public List<Player> Players { get; set; }

        public string TeamName { get; set; }
    }
}
