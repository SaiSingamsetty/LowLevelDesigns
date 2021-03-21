using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;

namespace CabBookingApp.Strategies
{
    public class DefaultCabMatchStrategy : ICabMatchStrategy
    {
        public Cab GetCabMatchForTheRider(Rider rider, List<Cab> optionCabs, Location fromPoint, Location toPoint)
        {
            if (optionCabs == null || !optionCabs.Any())
            {
                return null;
            }

            return optionCabs[0];
        }
    }
}
