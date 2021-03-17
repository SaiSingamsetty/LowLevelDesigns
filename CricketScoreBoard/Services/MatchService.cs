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

        public Match CreateMatch(int noOfPlayers, int noOfOvers)
        {
            if (_repository.Match != null)
            {
                throw new CustomException(400, "Match is currently in progress");
            }

            _repository.Match = new Match()
            {
                NoOfOvers = noOfOvers,
                NoOfPlayers = noOfPlayers,
                MatchId = Guid.NewGuid(),
            };

            return _repository.Match;
        }

        public void SetBattingOrder(List<string> playerNames)
        {
            if (_repository.Match != null)
            {
                _repository.MatchData = new MatchData {MatchReference = _repository.Match.MatchId};

                if (_repository.MatchData.HomeTeam != null)
                {
                    _repository.MatchData.HomeTeam = new ScoreCard()
                    {
                        BattingCard = new List<PlayerBattingData>()
                    };
                }
                else if (_repository.MatchData.OpponentTeam != null)
                {
                    _repository.MatchData.OpponentTeam = new ScoreCard()
                    {
                        BattingCard = new List<PlayerBattingData>()
                    };
                }
                else
                {
                    throw new CustomException(400, "Both the teams are already set");
                }
            }
            

        }


    }
}
