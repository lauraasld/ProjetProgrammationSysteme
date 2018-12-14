using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom
{
    public class HeadWaiter : DiningRoomStaff
    {
        private Dictionary<int, DateTime> timeWhenMenusWereGivenToTable;
        private Menu menu = new Menu();

        public HeadWaiter(DiningRoom diningRoom) : base(diningRoom)
        {
            timeWhenMenusWereGivenToTable = new Dictionary<int, DateTime>();
        }

        public void PlaceCustomersAtTable(CustomersGroup customers, int tableNumber)
        {
            diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers = customers.Customers;
            GiveMenuToCustomer(tableNumber);
        }

        private void GiveMenuToCustomer(int tableNumber)
        {
            foreach (var customer in diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers)
            {
                customer.menu = diningRoom.Countertop.Menus.First();
            }
        }

        public void TakeOrders(int tableNumber)
        {
            Table table = diningRoom.Tables.First(x => x.TableNumber == tableNumber);
            foreach (var customer in table.SeatedCustomers)
            {
                customer.ChooseRecipes(menu, table.OrderedDishes);
            }
            GiveOrdersToKitchen(tableNumber);

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