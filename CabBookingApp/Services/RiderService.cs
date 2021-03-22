using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Exceptions;
using CabBookingApp.Models;

namespace CabBookingApp.Services
{
    public class RiderService
    {
        private static readonly Dictionary<string, Rider> Riders = new Dictionary<string, Rider>();

        public void CreateRider(Rider rider)
        {
            if (Riders.ContainsKey(rider.Id))
            {
                throw new CustomException("SAME_RIDER_EXISTS", 409);
            }

            Riders.Add(rider.Id, rider);
        }

        public Rider GetRider(string riderId)
        {
            if (!Riders.ContainsKey(riderId))
            {
                throw new CustomException("RIDER_NOT_FOUND", 400);
            }

            return Riders[riderId];
        }
        
    }
}
