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
                MatchStatus = MatchStatus.YetToStart
            };

            return _repository.Match;
        }

        public void StartInnings(List<string> playersOrder)
        {
            if (_repository.Match.HomeTeamInnings == null)
            {
                _repository.Match.HomeTeamInnings = new Innings()
                {
                    BattingStatistics = playersOrder.Select(x=> new BattingStats()
                    {
                        PlayerId = x,
                        Status = PlayerStatus.YetToBat
                    }).ToList()
                };
                _repository.Match.MatchStatus = MatchStatus.InProgress;
            }
            else if(_repository.Match.OpponentTeamInnings == null)
            {
                _repository.Match.OpponentTeamInnings = new Innings()
                {
                    BattingStatistics = playersOrder.Select(x => new BattingStats()
                    {
                        PlayerId = x,
                        Status = PlayerStatus.YetToBat
                    }).ToList()
                };
                _repository.Match.MatchStatus = MatchStatus.InProgress;
            }
            else
            {
                throw new CustomException("Both the innings are started.");
            }
        }

        public void AddOverDataToActiveInnings(List<string> runsOfOver)
        {
            if (!_repository.Match.HomeTeamInnings.IsInningsCompleted)
            {
                AddOver(_repository.Match.HomeTeamInnings, runsOfOver);
            }
            else if (!_repository.Match.OpponentTeamInnings.IsInningsCompleted)
            {
                AddOver(_repository.Match.OpponentTeamInnings, runsOfOver);
            }
        }

        private void AddOver(Innings activeInnings, List<string> overData)
        {
            foreach (var eachBall in overData)
            {
                activeInnings.BallsPlayed++;

                if (eachBall == "1" || eachBall == "3")
                {
                    
                }
                else if (eachBall == "2")
                {

                }
                else if (eachBall == "4")
                {

                }
                else if (eachBall == "6")
                {

                }
                else if (eachBall == "W")
                {

                }
                else if(eachBall == "Wd")
                {
                    
                }
            }
        }

    }
}
