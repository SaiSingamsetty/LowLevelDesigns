using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class ParkingLot
    {
        public int Capacity { get; set; }

        public List<Slot> Slots { get; set; }

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
            Slots = new List<Slot>();
        }

        public Slot GetSlot(int slotNumber)
        {
            var slot = Slots.FirstOrDefault(x => x.SlotNumber == slotNumber);
            if (slot == null)
            {
                var newSlot = new Slot()
                {
                    SlotNumber = slotNumber
                };
                Slots.Add(newSlot);
                return newSlot;
            }

            return slot;
        }

        public Slot ParkCar(Car car, int slotNumber)
        {
            if (slotNumber > Capacity)
            {
                Console.WriteLine("Invalid Slot");
            }

            var slot = GetSlot(slotNumber);
            if(slot.IsSlotFree())
                slot.AssignCar(car);
            else
            {
                Console.WriteLine("Slot is not available");
            }

            return slot;
        }

        public Slot RemoveCar(int slotNumber)
        {
            var slot = GetSlot(slotNumber);
            slot.UnAssignCar();
            return slot;
        }
    }
}
