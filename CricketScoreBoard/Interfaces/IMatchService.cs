using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Models;

namespace CricketScoreBoard.Interfaces
{
    public interface IMatchService
    {
        Match CreateMatch(int noOfPlayers, int noOfOvers);

        void StartInnings(List<string> playersOrder);
    }
}
