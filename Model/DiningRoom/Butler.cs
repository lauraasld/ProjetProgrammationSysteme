using System;
namespace DiningRoom {
	public class Butler : DiningRoomStaff  {
		public void ServiceStart() {
			throw new System.Exception("Not implemented");
		}
		public bool AssignTable(ref CustomersGroup customers, ref bool hasBooked) {
			throw new System.Exception("Not implemented");
		}
		private int CheckAvailableTable(ref int numberOfSeats) {
			throw new System.Exception("Not implemented");
		}
		private int FindBookedTable(ref int numberOfSeats) {
			throw new System.Exception("Not implemented");
		}

	}

}
