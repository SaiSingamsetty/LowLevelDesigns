using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreBoard.Exceptions
{
    public class CustomException : Exception
    {
        public string ErrorMessage { get; set; }

        public int HttpStatusCode { get; set; }

        public CustomException(string message) : base(message)
        {
            ErrorMessage = message;
            HttpStatusCode = 500;
        }

        public CustomException(int code, string message) : base(message)
        {
            ErrorMessage = message;
            HttpStatusCode = code;
        }
    }
}
