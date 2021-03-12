using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    public class Slot
    {
        public Car ParkedCar { get; set; }

        public int SlotNumber { get; set; }

        public bool IsSlotFree()
        {
            return ParkedCar == null;
        }

        public void AssignCar(Car car)
        {
            ParkedCar = car;
        }

        public void UnAssignCar()
        {
            ParkedCar = null;
        }
    }
}
