using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Models
{
    public class ScoreCard
    {
        public List<PlayerBattingData> BattingCard { get; set; }

        public List<PlayerBowlingData> BowlingCard { get; set; }

        public int TotalScore { get; set; }

        public int TotalWickets { get; set; }

        public int TotalBalls { get; set; }

        public int Wides { get; set; }

        public int NoBalls { get; set; }

        public bool Is { get; set; }
    }
}
