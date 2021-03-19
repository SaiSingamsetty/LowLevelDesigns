using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;

namespace ParkingLot.Commands
{
    public abstract class CommandExecutor
    {
        public abstract bool Validate(Command command);
        public abstract void Execute(Command command);
    }
}
