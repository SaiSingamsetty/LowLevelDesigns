using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Parking
{
    public class ParkingStrategy : IParkingStrategy
    {
        private readonly SortedSet<int> _slotSortedSet;

        public ParkingStrategy()
        {
            _slotSortedSet = new SortedSet<int>();
        }

        public void AddSlot(int slotNumber)
        {
            _slotSortedSet.Add(slotNumber);
        }

        public void RemoveSlot(int slotNumber)
        {
            _slotSortedSet.Remove(slotNumber);
        }

        public int GetNextSlot()
        {
            if (_slotSortedSet.Count == 0)
            {
                throw new Exception("No slots available");
            }

            return _slotSortedSet.First();
        }
    }
}
