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
        private readonly Dictionary<string, Rider> _riders = new Dictionary<string, Rider>();

        public void CreateRider(Rider rider)
        {
            if (_riders.ContainsKey(rider.GetId()))
            {
                throw new CustomException("SAME_RIDER_EXISTS", 409);
            }

            _riders.Add(rider.GetId(), rider);
        }

        public Rider GetRider(string riderId)
        {
            if (!_riders.ContainsKey(riderId))
            {
                throw new CustomException("RIDER_NOT_FOUND", 400);
            }

            return _riders[riderId];
        }
        
    }
}
