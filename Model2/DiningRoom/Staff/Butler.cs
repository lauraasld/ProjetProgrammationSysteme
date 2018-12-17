using System; using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom {
	public class Butler : DiningRoomStaff  {

        public Butler(DiningRoom diningRoom) : base(diningRoom)
        {

        }

        public void ServiceStart() {
          throw new System.Exception("Not implemented");
        }

        public int FindTable(CustomersGroup customers)
        {
            Table firstMatchedTable;
            do
            {
                var listTableAvailable = diningRoom.Tables.Where(table => table.IsBooked == customers.HasBooked && table.IsAvailable == true);
                var listMatchedTable = listTableAvailable.Where(table => table.NumberOfPlaces >= customers.Customers.Count()).OrderBy(table => table.NumberOfPlaces);
                firstMatchedTable = listMatchedTable.FirstOrDefault();
            } while (firstMatchedTable == null);
            firstMatchedTable.IsAvailable = false;
            //headWaiter.PlaceCustomersAtTable(customers, firstMatchedTable.TableNumber);//TODO
            return firstMatchedTable.TableNumber;
        }

        public int CreateBooking(CustomersGroup customers, DateTime bookingTime)
        {
            Table firstMatchedTable;
            do
            {
                var listTableAvailable = diningRoom.Tables.Where(table => table.IsBooked == false && table.IsAvailable == true);
                var listMatchedTable = listTableAvailable.Where(table => table.NumberOfPlaces >= customers.Customers.Count()).OrderBy(table => table.NumberOfPlaces);
                firstMatchedTable = listMatchedTable.FirstOrDefault();
            } while (firstMatchedTable == null);
            firstMatchedTable.IsBooked = true;
            diningRoom.Reception.BookedCustomersGroups.Add(customers, bookingTime);
            //headWaiter.PlaceCustomersAtTable(customers, firstMatchedTable.TableNumber);//TODO
            return firstMatchedTable.TableNumber;
        }
    }
}
