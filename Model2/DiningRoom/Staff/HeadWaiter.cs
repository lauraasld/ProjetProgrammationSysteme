using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom
{
    public class HeadWaiter : DiningRoomStaff
    {
        private Dictionary<int, DateTime> timeWhenMenusWereGivenToTable;
        //private Menu menu = new Menu();

        public HeadWaiter(DiningRoom diningRoom) : base(diningRoom)
        {
            timeWhenMenusWereGivenToTable = new Dictionary<int, DateTime>();
        }

        public void PlaceCustomersAtTable(CustomersGroup customers, int tableNumber)
        {
            StartAction("Amène " + customers.Customers.Count + " clients à la table", 1);
            diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers = customers.Customers;
            EndAction();
            GiveMenuToCustomer(tableNumber);
        }

        private void GiveMenuToCustomer(int tableNumber)
        {
            StartAction("Donne les menus à la table " + tableNumber, 1);
            foreach (var customer in diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers)
            {
                customer.Menu = diningRoom.Countertop.Menus.First();
            }
            EndAction();
        }

        public void TakeOrders(int tableNumber)
        {
            StartAction("Prend les commandes à la table " + tableNumber, 1);
            Table table = diningRoom.Tables.First(x => x.TableNumber == tableNumber);
            foreach (var customer in table.SeatedCustomers)
            {
                customer.ChooseRecipes(table.OrderedDishes);
            }
            GiveOrdersToKitchen(tableNumber);
            EndAction();
        }

        private void GiveOrdersToKitchen(int tableNumber)
        {
            diningRoom.Countertop.Orders.Add(diningRoom.Tables.First(x => x.TableNumber == tableNumber));
        }

        public void SetTheTable()
        {
            throw new System.Exception("Not implemented");
        }
    }
}