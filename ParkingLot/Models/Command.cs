using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class Command
    {
        private string CommandName { get; }

        private string[] Params { get; }

        public string GetCommandName()
        {
            return CommandName;
        }

        public string[] GetParams()
        {
            return Params;
        }

        public Command(string input)
        {
            var arguments = input.Split(' ');
            CommandName = arguments[0].ToLower();
            Params = arguments.Skip(1).ToArray();
        }
    }
}
