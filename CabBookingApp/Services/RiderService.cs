using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Models;

namespace CabBookingApp.Services
{
    public class RiderService
    {
        private readonly Dictionary<string, Rider> _riders = new Dictionary<string, Rider>();

        public void CreateRider(Rider rider)
        {
            //TODO: Exception if same rider exists
            if (_riders.ContainsKey(rider.GetId()))
            {

            }

            _riders.Add(rider.GetId(), rider);
        }

        public Rider GetRider(string riderId)
        {
            //TODO: Exception if Rider with ID does not exist
            if (!_riders.ContainsKey(riderId))
            {

            }

            return _riders[riderId];
        }
        
    }
}
