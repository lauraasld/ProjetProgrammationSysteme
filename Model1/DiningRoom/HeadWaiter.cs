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
		}

		private void GiveMenuToCustomer(int tableNumber) {
            

            throw new System.Exception("Not implemented");
		}

		public void TakeOrders() {
			throw new System.Exception("Not implemented");
		}

		private void GiveOrdersToKitchen() {
			throw new System.Exception("Not implemented");
		}

		public void SetTheTable() {
			throw new System.Exception("Not implemented");
		}

	}

}
