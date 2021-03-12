using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using ParkingLot.Parking;
using ParkingLot.Service;

namespace ParkingLot.Commands
{
    public class CreateParkingLotCommandExecutor : CommandExecutor
    {
        public static string CommandName = "create_parking_lot";

        private readonly ParkingLotService _parkingLotService;
        public CreateParkingLotCommandExecutor(ParkingLotService parkingLotService) : base(parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        { 
            var commandParams = command.GetParams();
            if (commandParams.Length != 1)
            {
                return false;
            }

            var isValidInt = int.TryParse(commandParams[0], out _);
            return isValidInt;
        }

        public override void Execute(Command command)
        {
            var capacity = int.Parse(command.GetParams()[0]);
            var lot = new Models.ParkingLot(capacity);
            _parkingLotService.CreateParkingLot(lot, new ParkingStrategy());
            Console.WriteLine("Created parking lot");
        }
    }
}
