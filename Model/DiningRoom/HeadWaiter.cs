using System;
namespace DiningRoom {
	public class HeadWaiter : DiningRoomStaff  {
		private Dictionnary<TableNumber, DateTime> timeWhenMenusWereGiven;
		private List<TableOrder> tableOrders;

		public void PlaceCustomersAtTable(ref CustomersGroup customers, ref int tableNumber) {
			throw new System.Exception("Not implemented");
		}
		private void GiveMenuToCustomer(ref int tableNumber) {
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

		private TableOrder tableOrder;

	}

}
