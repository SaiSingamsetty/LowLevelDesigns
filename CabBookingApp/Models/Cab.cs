using System;

namespace CabBookingApp.Models
{
    public class Cab
    {
        public string Id { get; private set; }

        private string Driver { get; set; }

        public bool IsCabAvailable { get; set; }

        public Location CurrentLocation { get; set; }

        public Trip CurrentTrip { get; set; }
        
        public Cab(string driver)
        {
            Driver = driver;
            IsCabAvailable = true;
            Id = Guid.NewGuid().ToString();
        }
    }
}
