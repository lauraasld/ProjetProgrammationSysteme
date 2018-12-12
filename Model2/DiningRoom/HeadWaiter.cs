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
            foreach (var customer in customers.Customers)
            {
                diningRoom.Tables.First(x => x.TableNumber == tableNumber).Places.First(x => x.SeatedCustomer == null).SeatedCustomer = customer;
            }
            GiveMenuToCustomer(tableNumber);
        }

        private void GiveMenuToCustomer(int tableNumber)
        {
            foreach (var place in diningRoom.Tables.First(x => x.TableNumber == tableNumber).Places)
            {
                place.SeatedCustomer.menu = diningRoom.Countertop.Menus.First();
            }
        }

        public void TakeOrders(int tableNumber)
        {
            foreach (var place in diningRoom.Tables.First(x => x.TableNumber == tableNumber).Places.Where(x => x.SeatedCustomer != null))
            {
                place.SeatedCustomer.ChooseRecipes(menu);
            }            
        }

        private void GiveOrdersToKitchen(int tableNumber)
        {
            diningRoom.Countertop.Orders = TakeOrders(diningRoom.Tables.First(x => x.TableNumber == tableNumber).TableNumber);
        }

        public void SetTheTable()
        {
            throw new System.Exception("Not implemented");
        }
    }
}
