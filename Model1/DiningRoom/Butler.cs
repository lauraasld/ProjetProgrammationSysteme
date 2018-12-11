using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public class Butler : DiningRoomStaff  {
        public Butler(DiningRoom diningRoom) : base(diningRoom)
        {

        }

		public void ServiceStart() {
			throw new System.Exception("Not implemented");
		}
		public bool AssignTable(CustomersGroup customers, bool hasBooked) {
			throw new System.Exception("Not implemented");
		}
		private int CheckAvailableTable(int numberOfSeats) {
			throw new System.Exception("Not implemented");
		}
		private int FindBookedTable(int numberOfSeats) {
			throw new System.Exception("Not implemented");
		}

	}

}
