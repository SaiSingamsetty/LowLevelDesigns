using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {
        }

        public CustomException(string msg, int code) : base(msg)
        {
        }
    }
}
