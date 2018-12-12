using Model.DiningRoom;
using System.Collections.Generic;

namespace Model.Kitchen
{
    public class Countertop
    {
        private List<IPlatesToServeObserver> newPlateIsReadyObservers;
        public List<SmallItem> ItemsGoingToKitchen;
        public List<SmallItem> ItemsGoingToDiningRoom;
        public List<Plate> PlatesToServe;
        public List<SmallItem> KitchenwareStorage;
        public List<Menu> Menus;
        public List<Table> Orders;

        public Countertop()
        {
            newPlateIsReadyObservers = new List<IPlatesToServeObserver>();
            ItemsGoingToKitchen = new List<SmallItem>();
            ItemsGoingToDiningRoom = new List<SmallItem>();
            PlatesToServe = new List<Plate>();
            KitchenwareStorage = new List<SmallItem>();
            Menus = new List<Menu>();
            Orders = new List<Table>();
        }

        public void SubscribeToNewPlateIsReady(DiningRoom.IPlatesToServeObserver observer)
        {
            newPlateIsReadyObservers.Add(observer);
        }
        public void UnsubscribeToNewPlateIsReady(DiningRoom.IPlatesToServeObserver observer)
        {
            newPlateIsReadyObservers.Remove(observer);
        }
        public void NotifyObserversThatNewPlateIsReady()
        {
            foreach (IPlatesToServeObserver observer in newPlateIsReadyObservers)
            {
                observer.NewPlateIsReady();
            }
        }
    }
}
