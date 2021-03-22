using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingApp.Exceptions
{
    public class CustomException : Exception
    {
        private string ErrMsg { get; set; }

        private int StatusCode { get; set; }

        public CustomException(string msg) : base(msg)
        {
            ErrMsg = msg;
            StatusCode = 500;
        }

        public CustomException(string msg, int code) : base(msg)
        {
            ErrMsg = msg;
            StatusCode = code;
        }
    }
}
