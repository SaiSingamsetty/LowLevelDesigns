using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Models
{
    public class Cab
    {
        private string Id { get; set; }

        private string Driver { get; set; }

        public bool IsCabAvailable { get; set; }

        public Location CurrentLocation { get; set; }

        public Trip CurrentTrip { get; set; }

        public string GetId()
        {
            return Id;
        }

        public void UpdateCabAvailability(bool isAvailable)
        {
            IsCabAvailable = isAvailable;
        }

        public void UpdateCabLocation(Location newLocation)
        {
            CurrentLocation = newLocation;
        }
        
        public Cab(string driver)
        {
            Driver = driver;
            IsCabAvailable = true;
            Id = Guid.NewGuid().ToString();
        }
    }
}
