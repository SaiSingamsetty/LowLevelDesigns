using System;

namespace CabBookingApp.Models
{
    public class Location
    {
        private double X { get; set; }

        private double Y { get; set; }

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(Location fromLocation)
        {
            return Math.Sqrt(Math.Pow(X - fromLocation.X, 2) + Math.Pow(Y - fromLocation.Y, 2));
        }
    }
}