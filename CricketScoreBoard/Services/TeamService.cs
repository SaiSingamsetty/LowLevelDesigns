using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Models;

namespace CricketScoreBoard.Services
{
    public class TeamService : ITeamService
    {
        private readonly Repository.Repository _repository;

        public TeamService(Repository.Repository repository)
        {
            _repository = repository;
        }

        public Team CreateTeam(Team team)
        {
            var newPlayers = new List<Player>();
            foreach (var teamPlayer in team.Players)
            {
                var count = _repository.Players.Count;
                var newPlayer = new Player()
                {
                    Id = ++count,
                    Name = teamPlayer.Name
                };
                _repository.Players.Add(newPlayer);
                newPlayers.Add(newPlayer);
            }

            var teamCount = _repository.Teams.Count;
            _repository.Teams.Add(new Team()
            {
                TeamId = ++teamCount,
                Players = newPlayers,
                TeamName = team.TeamName
            });

            return _repository.Teams.Last();
        }

    }

    public interface ITeamService
    {
        Team CreateTeam(Team team);
    }
}
