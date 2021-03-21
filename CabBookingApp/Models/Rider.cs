using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Models
{
    public class Rider
    {
        private string Id { get; set; }

        private string RiderName { get; set; }

        public string GetId()
        {
            return Id;
        }

        public Rider(string name)
        {
            Id = Guid.NewGuid().ToString();
            RiderName = name;
        }
    }
}
