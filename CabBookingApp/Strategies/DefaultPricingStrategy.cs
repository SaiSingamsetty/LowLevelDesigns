using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;

namespace CabBookingApp.Strategies
{
    public class DefaultPricingStrategy : IPricingStrategy
    {
        public double CalculatePrice(Location @from, Location to)
        {
            return from.GetDistance(to) * 10;
        }
    }
}
