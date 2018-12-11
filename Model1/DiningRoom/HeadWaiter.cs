using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public class HeadWaiter : DiningRoomStaff  {
		private Dictionary<int, DateTime> timeWhenMenusWereGivenToTable;
		private List<TableOrder> tableOrders;

        public HeadWaiter(DiningRoom diningRoom) : base(diningRoom)
        {
            timeWhenMenusWereGivenToTable = new Dictionary<int, DateTime>();
            tableOrders = new List<TableOrder>();
        }

        public void PlaceCustomersAtTable(CustomersGroup customers, int tableNumber) {
			throw new System.Exception("Not implemented");
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
