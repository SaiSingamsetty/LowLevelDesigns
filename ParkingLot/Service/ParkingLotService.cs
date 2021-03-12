using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingLot.Exceptions;
using ParkingLot.Parking;
using ParkingLot.Models;

namespace ParkingLot.Service
{
    public class ParkingLotService
    {
        private Models.ParkingLot _parkingLot;

        private ParkingStrategy _parkingStrategy;

        public void CreateParkingLot(Models.ParkingLot parkingLot, ParkingStrategy strategy)
        {
            if (_parkingLot != null)
            {
                throw new Exception("Parking lot already exists");
            }

            _parkingLot = parkingLot;
            _parkingStrategy = strategy;
            for (int i = 1; i <= _parkingLot.Capacity; i++)
            {
                _parkingStrategy.AddSlot(i);
            }
        }

        private void ValidateParkingLotExists()
        {
            if (_parkingLot == null)
            {
                throw new ParkingLotException("Parking lot does not exists to park.");
            }
        }

        public int ParkCar(Car car)
        {
            try
            {
                ValidateParkingLotExists();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var nextFreeSlot = _parkingStrategy.GetNextSlot();
            _parkingLot.ParkCar(car, nextFreeSlot);
            _parkingStrategy.RemoveSlot(nextFreeSlot);
            return nextFreeSlot;
        }

        public void EmptySlot(int slotNumber)
        {
            ValidateParkingLotExists();
            _parkingLot.RemoveCar(slotNumber);
            _parkingStrategy.AddSlot(slotNumber);
        }

        public List<Slot> GetOccupiedSlots()
        {
            ValidateParkingLotExists();

            var occSlots = new List<Slot>();

            for (int i = 1; i <= _parkingLot.Capacity; i++)
            {
                var slot = _parkingLot.GetSlot(i);

                if(!slot.IsSlotFree())
                    occSlots.Add(_parkingLot.Slots[i-1]);
            }

            return occSlots;
        }

        public List<Slot> GetSlotsForColor(string color)
        {
            var occupiedSlots = GetOccupiedSlots();
            return occupiedSlots.Where(slot => slot.ParkedCar.Color.Equals(color)).ToList();
        }

    }
}
