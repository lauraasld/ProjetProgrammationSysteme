using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public class Reception {
		public List<CustomersGroup> WaitingCustomersGroups;
		public Dictionary<CustomersGroup, DateTime> BookedCustomersGroups;

		private void CreateBooking() {
			throw new System.Exception("Not implemented");
		}

		private CustomersGroup customersGroup;


	}

}
