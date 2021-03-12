using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using ParkingLot.Service;

namespace ParkingLot.Commands
{
    public abstract class CommandExecutor
    {
        protected ParkingLotService ParkingLotService;

        protected CommandExecutor(ParkingLotService parkingLotService)
        {
            ParkingLotService = parkingLotService;
        }

        public abstract bool Validate(Command command);
        public abstract void Execute(Command command);
    }
}
