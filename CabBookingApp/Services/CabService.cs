using CabBookingApp.Exceptions;
using CabBookingApp.Models;
using System.Collections.Generic;

namespace CabBookingApp.Services
{
    public class CabService
    {
        private static readonly Dictionary<string, Cab> Cabs = new Dictionary<string, Cab>();

        public void CreateCab(Cab cab)
        {
            if (Cabs.ContainsKey(cab.Id))
            {
                throw new CustomException("CAB_ALREADY_EXISTS", 409);
            }

            Cabs.Add(cab.Id, cab);
        }

        public Cab GetCab(string cabId)
        {
            if (!Cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            return Cabs[cabId];
        }

        public void UpdateCabLocation(string cabId, Location location)
        {
            if (!Cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            Cabs[cabId].CurrentLocation = location;
        }

        public void UpdateCabAvailability(string cabId, bool isAvailable)
        {
            if (!Cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            Cabs[cabId].IsCabAvailable = isAvailable;
        }

        public List<Cab> GetCabs(Location from, double distance)
        {
            var cabsList = new List<Cab>();

            foreach (var eachCab in Cabs.Values)
            {
                if(eachCab.IsCabAvailable && eachCab.CurrentTrip == null && eachCab.CurrentLocation.GetDistance(from) <= distance)
                    cabsList.Add(eachCab);
            }

            return cabsList;
        }
    }
}
