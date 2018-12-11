using System; using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom {
	public class HeadWaiter : DiningRoomStaff  {
		private Dictionary<int, DateTime> timeWhenMenusWereGiven;
		private List<TableOrder> tableOrders;
        private TableOrder tableOrder;
        
        public void PlaceCustomersAtTable(CustomersGroup customers, int tableNumber) {
			foreach (var customer in customers.Customers)
            {
                diningRoom.Tables.First(x => x.TableNumber == tableNumber).Places.First(x => x.SeatedCustomer == null).SeatedCustomer = customer;
            }
            GiveMenuToCustomer(tableNumber);
		}

		private void GiveMenuToCustomer(int tableNumber)
        {
            foreach (var place in diningRoom.Tables.First(x => x.TableNumber == tableNumber).Places)
            {
                place.SeatedCustomer.menu = diningRoom.Countertop.Menus.First();
            }         
		}

		public void TakeOrders(int tableNumber) {

			throw new System.Exception("Not implemented");
		}

		private void GiveOrdersToKitchen(int tableNumber) {
			throw new System.Exception("Not implemented");
		}

		public void SetTheTable() {
			throw new System.Exception("Not implemented");
		}

	}

}
