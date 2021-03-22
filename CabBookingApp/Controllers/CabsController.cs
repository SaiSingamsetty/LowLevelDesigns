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
    public class CabsController : ControllerBase
    {
        private readonly TripService _tripService;
        private readonly CabService _cabService;

        public CabsController(TripService tripService, CabService cabService)
        {
            _tripService = tripService;
            _cabService = cabService;
        }

        [HttpPost("register")]
        public ActionResult Register([FromQuery] string driverName)
        {
            _cabService.CreateCab(new Cab(driverName));
            return Ok();
        }

        [HttpPut("{cabId}/location")]
        public ActionResult UpdateCabLocation([FromRoute] string cabId, [FromQuery] double newX,
            [FromQuery] double newY)
        {
            _cabService.UpdateCabLocation(cabId, new Location(newX, newY));
            return Ok();
        }

        [HttpPut("{cabId}/availability")]
        public ActionResult UpdateCabAvailability([FromRoute] string cabId, [FromQuery] bool isAvailable)
        {
            _cabService.UpdateCabAvailability(cabId, isAvailable);
            return Ok();
        }

        [HttpPut("{cabId}/end-trip")]
        public ActionResult FinishTrip([FromRoute] string cabId)
        {
            _tripService.FinishTrip(_cabService.GetCab(cabId));
            return Ok();
        }
    }
}
