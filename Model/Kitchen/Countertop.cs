using System;
namespace Kitchen {
	public class Countertop {
		private List<DiningRoom.IPlatesToServeObserver> newPlateIsReadyObservers;
		public List<SmallItem> ItemsGoingToKitchen;
		public List<SmallItem> ItemsGoingToDiningRoom;
		public List<SmallItem> PlatesToServe;
		public List<SmallItem> KitchenwareStorage;
		public List<DiningRoom.Menu> Menus;
		public List<DiningRoom.TableOrder> Orders;

		public void SubscribeToNewPlateIsReady(ref DiningRoom.IPlatesToServeObserver observer) {
			throw new System.Exception("Not implemented");
		}
		public void UnsubscribeToNewPlateIsReady(ref DiningRoom.IPlatesToServeObserver observer) {
			throw new System.Exception("Not implemented");
		}
		public void NotifyObserversThatNewPlateIsReady() {
			throw new System.Exception("Not implemented");
		}

		private DiningRoom.IPlatesToServeObserver iPlatesToServeObserver;
		private SmallItem smallItem;

	}

}
