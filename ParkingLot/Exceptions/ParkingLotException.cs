using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Exceptions
{
    public class ParkingLotException : Exception
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public ParkingLotException()
        {

        }

        public ParkingLotException(string message) : base(message)
        {

        }

        public ParkingLotException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }

    }
}
