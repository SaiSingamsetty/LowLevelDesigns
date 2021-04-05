using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Exceptions;
using CricketScoreBoard.Interfaces;
using CricketScoreBoard.Models;
using Microsoft.VisualBasic;

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
                _repository.Match.HomeTeamInnings.BattingStatistics[0].Status = PlayerStatus.OnStrikeEnd;
                _repository.Match.HomeTeamInnings.BattingStatistics[1].Status = PlayerStatus.OnNonStrikeEnd;
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
                _repository.Match.OpponentTeamInnings.BattingStatistics[0].Status = PlayerStatus.OnStrikeEnd;
                _repository.Match.OpponentTeamInnings.BattingStatistics[1].Status = PlayerStatus.OnNonStrikeEnd;
            }
            else
            {
                throw new CustomException("Both the innings are started.");
            }
        }

        public ScoreCard AddOverDataToActiveInnings(List<string> runsOfOver)
        {
            if (!_repository.Match.HomeTeamInnings.IsInningsCompleted)
            {
                AddOver(_repository.Match.HomeTeamInnings, runsOfOver);
                return GetScoreCard(_repository.Match.HomeTeamInnings);
            }

            if (!_repository.Match.OpponentTeamInnings.IsInningsCompleted)
            {
                AddOver(_repository.Match.OpponentTeamInnings, runsOfOver);
                return GetScoreCard(_repository.Match.OpponentTeamInnings);
            }

            throw new CustomException("No active innings");
        }

        private ScoreCard GetScoreCard(Innings activeInnings)
        {
            var playersScores = activeInnings.BattingStatistics.Select(x => new PlayerScores()
            {
                Sixes = x.Sixes,
                Fours = x.Fours,
                Score = x.Score,
                Balls = x.NoOfBalls,
                IsNotOut = x.Status == PlayerStatus.OnStrikeEnd || x.Status == PlayerStatus.OnNonStrikeEnd,
                PlayerName = x.PlayerId
            });

            var scoreCard = new ScoreCard
            {
                PlayerScoresList = playersScores.ToList(),
                TotalBalls = activeInnings.BallsPlayed,
                TotalScore = activeInnings.TotalScore,
                WicketsDown = activeInnings.WicketsDown
            };

            return scoreCard;
        }

        private void AddOver(Innings activeInnings, List<string> overData)
        {
            foreach (var eachBall in overData)
            {
                activeInnings.BallsPlayed++;
                activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).NoOfBalls++;

                if (eachBall == "1" || eachBall == "3")
                {
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Score++;
                    var playerIdOnStrike = activeInnings.BattingStatistics
                        .First(x => x.Status == PlayerStatus.OnStrikeEnd).PlayerId;


                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnNonStrikeEnd).Status =
                        PlayerStatus.OnStrikeEnd;
                    activeInnings.BattingStatistics.First(x =>
                            x.PlayerId.Equals(playerIdOnStrike, StringComparison.InvariantCultureIgnoreCase))
                        .Status = PlayerStatus.OnNonStrikeEnd;

                    activeInnings.TotalScore++;
                }
                else if (eachBall == "2")
                {
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Score += 2;
                    activeInnings.TotalScore += 2;
                }
                else if (eachBall == "4")
                {
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Score += 4;
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Fours++;
                    activeInnings.TotalScore += 4;
                }
                else if (eachBall == "6")
                {
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Score += 6;
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Sixes++;
                    activeInnings.TotalScore += 6;
                }
                else if (eachBall == "W")
                {
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.OnStrikeEnd).Status = PlayerStatus.Out;
                    activeInnings.BattingStatistics.First(x => x.Status == PlayerStatus.YetToBat).Status =
                        PlayerStatus.OnStrikeEnd;
                    activeInnings.WicketsDown++;
                }
                else if(eachBall == "Wd")
                {
                    activeInnings.Extras++;
                    activeInnings.TotalScore += 1;
                }
            }

            if (activeInnings.BallsPlayed == _repository.Match.NoOfOvers * 6)
            {
                activeInnings.IsInningsCompleted = true;
            }

        }
    }
}
