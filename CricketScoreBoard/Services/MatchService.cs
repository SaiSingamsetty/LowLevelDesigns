using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Exceptions;
using CricketScoreBoard.Interfaces;
using CricketScoreBoard.Models;

namespace CricketScoreBoard.Services
{
    public class MatchService : IMatchService
    {
        private readonly Repository.Repository _repository;

        public MatchService(Repository.Repository repository)
        {
            _repository = repository;
        }

        public Match CreateMatch(int noOfPlayers, int noOfOvers, int teamOne, int teamTwo)
        {
            if (_repository.Match != null)
            {
                throw new CustomException(400, "Match is currently in progress");
            }

            if (_repository.Teams.Any(x => x.TeamId == teamOne) && _repository.Teams.Any(x => x.TeamId == teamTwo))
            {
                _repository.Match = new Match()
                {
                    NoOfOvers = noOfOvers,
                    NoOfPlayers = noOfPlayers,
                    TeamOneId = teamOne,
                    TeamTwoId = teamTwo,
                    MatchId = Guid.NewGuid()
                };

                return _repository.Match;
            }

            throw new CustomException(400, "Team/s does not exist");
        }

        public void SetBattingOrder(List<string> playerNames)
        {
            var teamOneBattingPlayers = new List<PlayerBattingData>();

            foreach (var playerName in playerNames)
            {
                var player = _repository.Players.First(x =>
                    x.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
                teamOneBattingPlayers.Add(new PlayerBattingData()
                {
                    PlayerId = player.Id
                });
            }
        }


    }
}
