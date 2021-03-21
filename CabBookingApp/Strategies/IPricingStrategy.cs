using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;

namespace CabBookingApp.Strategies
{
    public interface IPricingStrategy
    {
        double CalculatePrice(Location from, Location to);
    }
}
