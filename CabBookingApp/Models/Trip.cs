using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Models
{
    public class Trip
    {
        public Cab Cab { get; set; }

        public Rider Rider { get; set; }

        public TripStatus TripStatus { get; set; }

        public double Price { get; set; }

        public Location FromLocation { get; set; }

        public Location ToLocation { get; set; }

        public Trip(Cab cab, Rider rider, double price, Location from, Location to)
        {
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
