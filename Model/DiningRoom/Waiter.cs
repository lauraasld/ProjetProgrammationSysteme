using System;
namespace DiningRoom {
	public class Waiter : DiningRoomStaff , IPlatesToServeObserver  {
		public void GiveBreadAndWater(ref int tableNumber) {
			throw new System.Exception("Not implemented");
		}
		public void ServeFood(ref int tableNumber) {
			throw new System.Exception("Not implemented");
		}
		public void ClearPlates(ref int tableNumber) {
			throw new System.Exception("Not implemented");
		}
		public void ClearAndCleanTable(ref int tableNumber) {
			throw new System.Exception("Not implemented");
		}
		public void NewPlateIsReady() {
			throw new System.Exception("Not implemented");
		}

	}

}
