using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBookingApp.Exceptions;
using CabBookingApp.Models;
using CabBookingApp.Strategies;

namespace CabBookingApp.Services
{
    public class TripService
    {
        private readonly Dictionary<string, List<Trip>> _trips = new Dictionary<string, List<Trip>>();

        private static double _maxMatchingDistance = 10;

        private readonly CabService _cabService;

        private readonly RiderService _riderService;

        private readonly ICabMatchStrategy _cabMatchStrategy;

        private readonly IPricingStrategy _pricingStrategy;

        public TripService(CabService cabService, RiderService riderService, ICabMatchStrategy cabMatchStrategy, IPricingStrategy pricingStrategy)
        {
            _cabService = cabService;
            _riderService = riderService;
            _cabMatchStrategy = cabMatchStrategy;
            _pricingStrategy = pricingStrategy;
        }

        public void CreateTrip(Rider rider, Location fromPoint, Location toPoint)
        {
            var closeByCabs = _cabService.GetCabs(fromPoint, _maxMatchingDistance);

            var matchedCab = _cabMatchStrategy.GetCabMatchForTheRider(rider, closeByCabs, fromPoint, toPoint);
            if (matchedCab == null)
            {
                //TODO : Exception NOT FOUND
                throw new Exception(); 
            }

            var price = _pricingStrategy.CalculatePrice(fromPoint, toPoint);
            var newTrip = new Trip(matchedCab, rider, price, fromPoint, toPoint);
            if (!_trips.ContainsKey(rider.GetId()))
            {
                _trips.Add(rider.GetId(), new List<Trip>());
            }
            
            _trips[rider.GetId()].Add(newTrip);
            matchedCab.CurrentTrip = newTrip;
        }

        public List<Trip> GetTripHistory(string riderId)
        {
            return _trips[riderId];
        }

        public void FinishTrip(Cab cab)
        {
            if (cab.CurrentTrip == null)
            {
                throw new CustomException("TRIP_NOT_FOUND", 400);
            }

            cab.CurrentTrip.FinishTrip();
            cab.CurrentTrip = null;
        }

    }
}
