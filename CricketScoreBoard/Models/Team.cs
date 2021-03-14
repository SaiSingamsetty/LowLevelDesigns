using System.Collections.Generic;

namespace CricketScoreBoard.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public List<Player> Players { get; set; }

        public string TeamName { get; set; }
    }
}