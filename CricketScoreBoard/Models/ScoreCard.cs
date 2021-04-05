using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Models
{
    public class ScoreCard
    {
        public List<PlayerScores> PlayerScoresList { get; set; }

        public int TotalScore { get; set; }

        public int TotalBalls { get; set; }

        public int WicketsDown { get; set; } 
    }

    public class PlayerScores
    {
        public string PlayerName { get; set; }

        public bool IsNotOut { get; set; }

        public int Score { get; set; }

        public int Fours { get; set; }

        public int Sixes { get; set; }

        public int Balls { get; set; }
    }
}
