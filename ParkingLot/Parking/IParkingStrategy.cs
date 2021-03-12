using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Parking
{
    public interface IParkingStrategy
    {
        public void AddSlot(int slotNumber);
        
        public void RemoveSlot(int slotNumber);
        
        public int GetNextSlot();
    }
}
