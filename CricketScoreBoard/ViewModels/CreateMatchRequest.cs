using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.ViewModels
{
    public class CreateMatchRequest
    {
        public int NoOfPlayersInATeam { get; set; }

        public int NoOfOvers { get; set; }

        public int TeamOneId { get; set; }

        public int TeamTwoId { get; set; }
    }
}
