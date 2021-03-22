using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;
using CabBookingApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CabBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidersController : ControllerBase
    {
        private readonly TripService _tripService;
        private readonly RiderService _riderService;

        public RidersController(TripService tripService, RiderService riderService)
        {
            _tripService = tripService;
            _riderService = riderService;
        }
        
        [HttpPost("register")]
        public ActionResult RegisterRider([FromQuery] string riderName)
        {
            var newRider = new Rider(riderName);
            _riderService.CreateRider(newRider);
            return Ok(newRider);
        }

        [HttpPost("book")]
        public ActionResult BookCab([FromQuery] string riderId, [FromQuery] double sourceX, [FromQuery] double sourceY, [FromQuery] double destX, [FromQuery] double destY)
        {
            _tripService.CreateTrip(_riderService.GetRider(riderId), new Location(sourceX, sourceY), new Location(destX, destY));
            return Ok();
        }

        [HttpGet("{riderId}/history")]
        public ActionResult GetHistoryRides([FromRoute] string riderId)
        {
            var history = _tripService.GetTripHistory(riderId);
            return Ok(history);
        }
    }
}
