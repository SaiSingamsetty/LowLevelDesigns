using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using ParkingLot.Service;

namespace ParkingLot.Commands
{
    public class StatusCommandExecutor : CommandExecutor
    {
        public static string CommandName = "status";

        private readonly ParkingLotService _parkingLotService;

        public StatusCommandExecutor(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        {
            return command.GetParams().Length == 0;
        }

        public override void Execute(Command command)
        {
            var occupiedSlots = _parkingLotService.GetOccupiedSlots();
            if (occupiedSlots.Count == 0)
            {
                Console.WriteLine("All slots are free.");
                return;
            }

            foreach (var eachSlot in occupiedSlots)
            {
                Console.WriteLine($"Slot {eachSlot.SlotNumber}: Car : {eachSlot.ParkedCar.RegistrationNumber} of Color {eachSlot.ParkedCar.Color}");
            }

        }
    }
}
