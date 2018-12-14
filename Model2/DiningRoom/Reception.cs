using System;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Reception
    {
        public List<CustomersGroup> WaitingCustomersGroups;
        public Dictionary<CustomersGroup, DateTime> BookedCustomersGroups;

        public void CreateBooking()
        {
            throw new System.Exception("Not implemented");
        }

        public void BookedCustomersArrive(CustomersGroup arrivingGroup)
        {

        }
    }
}
