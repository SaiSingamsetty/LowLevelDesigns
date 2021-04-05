using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreBoard.Interfaces;

namespace CricketScoreBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InningsController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public InningsController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        public ActionResult StartInnings([FromBody] List<string> playerOrder)
        {
            _matchService.StartInnings(playerOrder);
            return Ok();
        }

        [HttpPost("over")]
        public ActionResult AddOverDataToInnings([FromBody] List<string> runsInTheOver)
        {
            var card =  _matchService.AddOverDataToActiveInnings(runsInTheOver);
            return Ok(card);
        }

    }
}
