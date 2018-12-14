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
            //foreach (var customer in customers.Customers)
            //{
            //    if(diningRoom.Tables.First(x => x.TableNumber == tableNumber).IsAvailable.(x => x.SeatedCustomer == null).SeatedCustomer = customer;
            //}
            //GiveMenuToCustomer(tableNumber);
        }

        private void GiveMenuToCustomer(int tableNumber)
        {
            foreach (var place in diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers)
            {
                place.menu = diningRoom.Countertop.Menus.First();
            }
        }

        public void TakeOrders(int tableNumber)
        {
            foreach (var place in diningRoom.Tables.First(x => x.TableNumber == tableNumber).SeatedCustomers.Where(x => x != null))
            {
                place.ChooseRecipes(menu, menu.AvailableDishes);
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
