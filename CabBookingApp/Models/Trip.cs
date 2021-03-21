using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Models
{
    public class Trip
    {
        private Cab Cab { get; set; }

        private Rider Rider { get; set; }

        private TripStatus TripStatus { get; set; }

        private double Price { get; set; }

        private Location FromLocation { get; set; }

        private Location ToLocation { get; set; }

        public Trip(Cab cab, Rider rider, double price, Location from, Location to)
        {
            Id = Guid.NewGuid().ToString();
            Cab = cab;
            Rider = rider;
            TripStatus = TripStatus.InProgress;
            Price = price;
            FromLocation = from;
            ToLocation = to;
        }

        public void FinishTrip()
        {
            TripStatus = TripStatus.Finished;
        }
    }
}
