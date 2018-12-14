using System; using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom {
	public class Butler : DiningRoomStaff  {

        private HeadWaiter headWaiter;

        public Butler(DiningRoom diningRoom) : base(diningRoom)
        {

        }

        public void ServiceStart() {
          throw new System.Exception("Not implemented");
        }

        public bool AssignTable(CustomersGroup customers)
        {
            var listTableAvailable = diningRoom.Tables.Where(table => table.IsBooked == customers.HasBooked && table.IsAvailable == true);
            var listMatchedTable = listTableAvailable.Where(table => table.NumberOfPlaces >= customers.Customers.Count()).OrderBy(table => table.NumberOfPlaces);
            var firstMatchedTable = listMatchedTable.First();
            headWaiter.PlaceCustomersAtTable(customers, firstMatchedTable.TableNumber);//TODO
            return firstMatchedTable.IsAvailable == false;
        }
    }
}
