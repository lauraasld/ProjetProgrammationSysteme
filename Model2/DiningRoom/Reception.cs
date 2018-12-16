using System;
using System.Linq;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Reception
    {
        public List<CustomersGroup> WaitingCustomersGroups;
        public Dictionary<CustomersGroup, DateTime> BookedCustomersGroups;

        public Reception()
        {
            WaitingCustomersGroups = new List<CustomersGroup>();
            BookedCustomersGroups = new Dictionary<CustomersGroup, DateTime>();
        }

        /*public void CreateBooking()
        {
            throw new System.Exception("Not implemented");
        }*/

        public void BookedCustomersArrive(CustomersGroup arrivingGroup)
        {
            WaitingCustomersGroups.Add(BookedCustomersGroups.First(x => x.Key == arrivingGroup).Key);
            BookedCustomersGroups.Remove(arrivingGroup);
        }
    }
}
