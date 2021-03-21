using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;

namespace CabBookingApp.Strategies
{
    public interface ICabMatchStrategy
    {
        Cab GetCabMatchForTheRider(Rider rider, List<Cab> optionCabs, Location fromPoint, Location toPoint);
    }
}
