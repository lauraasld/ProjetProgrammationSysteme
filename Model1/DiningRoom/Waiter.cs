using System; using System.Collections.Generic;

namespace Model.DiningRoom {
	public class Waiter : DiningRoomStaff , IPlatesToServeObserver  {
		public void GiveBreadAndWater(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void ServeFood(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void ClearPlates(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void ClearAndCleanTable(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void NewPlateIsReady() {
			throw new Exception("Not implemented");
		}

	}

}
