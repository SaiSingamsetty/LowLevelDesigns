using System;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Models
{
    public class Match
    {
        public Guid MatchId { get; set; }

        public int NoOfOvers { get; set; }

        public int NoOfPlayers { get; set; }

        public MatchStatus MatchStatus { get; set; }
    }

    public enum MatchStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }
}
