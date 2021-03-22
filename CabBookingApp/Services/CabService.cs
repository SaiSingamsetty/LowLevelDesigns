using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Exceptions;
using CabBookingApp.Models;

namespace CabBookingApp.Services
{
    public class CabService
    {
        private Dictionary<string, Cab> _cabs = new Dictionary<string, Cab>();

        public void CreateCab(Cab cab)
        {
            if (_cabs.ContainsKey(cab.GetId()))
            {
                throw new CustomException("CAB_ALREADY_EXISTS", 409);
            }

            _cabs.Add(cab.GetId(), cab);
        }

        public Cab GetCab(string cabId)
        {
            if (!_cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            return _cabs[cabId];
        }

        public void UpdateCabLocation(string cabId, Location location)
        {
            if (!_cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            _cabs[cabId].UpdateCabLocation(location);
        }

        public void UpdateCabAvailability(string cabId, bool isAvailable)
        {
            if (!_cabs.ContainsKey(cabId))
            {
                throw new CustomException("NO_CAB_FOUND", 400);
            }

            _cabs[cabId].UpdateCabAvailability(isAvailable);
        }

        public List<Cab> GetCabs(Location from, double distance)
        {
            var cabsList = new List<Cab>();

            foreach (var eachCab in _cabs.Values)
            {
                if(eachCab.IsCabAvailable && eachCab.CurrentTrip == null && eachCab.CurrentLocation.GetDistance(from) <= distance)
                    cabsList.Add(eachCab);
            }

            return cabsList;
        }
    }
}
