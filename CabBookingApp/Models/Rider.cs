using System;

namespace CabBookingApp.Models
{
    public class Rider
    {
        public string Id { get; set; }

        public string RiderName { get; set; }
        
        public Rider(string name)
        {
            Id = Guid.NewGuid().ToString();
            RiderName = name;
        }
    }
}
