using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Interfaces;
using CricketScoreBoard.Models;

namespace CricketScoreBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        public ActionResult CreateMatch([FromBody]Match request)
        {
            var response = _matchService.CreateMatch(request.NoOfPlayers, request.NoOfOvers);
            return Ok(response);
        }
        
    }
}
