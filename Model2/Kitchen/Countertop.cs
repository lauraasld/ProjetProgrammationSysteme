using Model.DiningRoom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Model.Kitchen
{
    public class Countertop
    {
        private List<IPlatesToServeObserver> newPlateIsReadyObservers;
        public List<SmallItem> ItemsGoingToKitchen;
        public List<SmallItem> ItemsGoingToDiningRoom;
        public static object LockObjPlatesToServe = new object();
        public ObservableCollection<Plate> PlatesToServe { get; set; }
        /*public List<Plate> PlatesToServe
        {
            get { return platesToServe; }
        }*/
        public List<SmallItem> KitchenwareStorage;
        public List<Menu> Menus;
        public List<Table> Orders;

        public Countertop()
        {
            newPlateIsReadyObservers = new List<IPlatesToServeObserver>();
            ItemsGoingToKitchen = new List<SmallItem>();
            ItemsGoingToDiningRoom = new List<SmallItem>();
            //PlatesToServe = new List<Plate>();
            /*platesToServe = new ObservableCollection<Plate>();
            platesToServe.CollectionChanged += NotifyObserversThatNewPlateIsReady;*/
            PlatesToServe = new ObservableCollection<Plate>();
            PlatesToServe.CollectionChanged += NotifyObserversThatNewPlateIsReady;
            KitchenwareStorage = new List<SmallItem>();
            Menus = new List<Menu>();
            Orders = new List<Table>();
        //    int serverPort = 8888;
        //    IPAddress serverAddress = IPAddress.Parse("127.0.0.1");
        //    TcpListener serverSocket = null;
        //    try
        //    {
        //        serverSocket = new TcpListener(serverAddress, serverPort);
        //        serverSocket.Start();
        //        // BUFFER FOR READING DATA
        //        Byte[] bytes = new Byte[256];
        //        String data = null;

        //        while (true)
        //        {
        //            TcpClient client = serverSocket.AcceptTcpClient();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        Console.WriteLine("Exception: {0}", error);
        //    }
        //    finally
        //    {
        //        serverSocket.Stop();
        //    }
        //}

        public void SubscribeToNewPlateIsReady(DiningRoom.IPlatesToServeObserver observer)
        {
            newPlateIsReadyObservers.Add(observer);
        }
        public void UnsubscribeToNewPlateIsReady(DiningRoom.IPlatesToServeObserver observer)
        {
            newPlateIsReadyObservers.Remove(observer);
        }
        private void NotifyObserversThatNewPlateIsReady(object sender, NotifyCollectionChangedEventArgs args)
        {
            //new Thread(delegate ()
            //{
                foreach (IPlatesToServeObserver observer in newPlateIsReadyObservers)
                {
                    observer.NewPlateIsReady();
                }
            //}).Start();

        }
    }
}
