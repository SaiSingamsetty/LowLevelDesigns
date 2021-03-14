using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Models;

namespace CricketScoreBoard.Repository
{
    public class Repository
    {
        public Match Match { get; set; }

        public List<Team> Teams { get; set; }

        public List<Player> Players { get; set; }

        public MatchData MatchData { get; set; }
    }
}
