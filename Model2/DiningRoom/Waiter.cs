using Model.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.DiningRoom {
	public class Waiter : DiningRoomStaff , IPlatesToServeObserver  {
        private double timeMultiplier = 1;
        public Waiter(DiningRoom diningRoom) : base(diningRoom)
        {            
            this.timeMultiplier = 1;
        }
        public void GiveBreadAndWater(int tableNumber) {
        }

		public void ServeFood(int tableNumber) {
            //faire un linq
            foreach (var diningRoomTable in diningRoom.Tables)
            {
                List<Plate> pTS = diningRoom.Countertop.PlatesToServe;
                List<TableOrder> orders = diningRoom.Countertop.Orders;
               
                if (diningRoomTable.TableNumber == tableNumber)
                {
                    //var test = from p in pTS
                    //           join o in orders on p.Dish.DishName equals o.Orders.Where(x => x.Value.DishName == p.Dish)
                    //           select p;

                    //foreach (var plate in pTS)
                    //{
                    //    diningRoom.Countertop.Orders.First(x => x.Orders.Values.ToList()
                    //    .ForEach(i => { if (i.DishName.Equals(plate.Dish.DishName) && x.CourseType.Equals(plate.Dish.CourseType)) { pTS.Remove(plate); } }));
                    //}
                    foreach (var order in orders)
                    {
                        List<Dish> ordersDish = order.Orders.Values.ToList();
                        foreach (var oDish in ordersDish)
                        {
                            foreach (var plat in pTS)
                            {
                                if (oDish.DishName.Equals(plat.Dish.DishName) && oDish.CourseType.Equals(plat.Dish.CourseType))
                                {
                                    foreach (var place in diningRoomTable.Places)
                                    {
                                        place.CookedFood = plat;
                                    }
                                    pTS.Remove(plat);
                                }
                            }
                        }
                        //Passer au CourseType suivant
                        if (order.NextCourseToServe == CourseType.Starter)
                        {
                            order.NextCourseToServe = CourseType.MainCourse;
                        }
                        else if (order.NextCourseToServe == CourseType.MainCourse)
                        {
                            order.NextCourseToServe = CourseType.Dessert;
                        }
                    }
                }
            }
            // ne prend en compte que CourseType
            // les Comparer a la liste PlateToServe
            //Si ok -> remove de la liste PlateToServe + CourseType+=1
        }
		public void ClearPlates(int tableNumber) {
            foreach (var diningRoomTable in diningRoom.Tables)
            {
                if (diningRoomTable.TableNumber == tableNumber)
                {
                    foreach (var place in diningRoomTable.Places)
                    {
                        if (place.CookedFood.IsFinished)
                        {
                            diningRoom.Countertop.ItemsGoingToKitchen.Add(place.CookedFood);
                            place.CookedFood = null;
                        }
                    }

                }
            }
            //quand plat fini, alors débarasse IsReadyToServe == true
        }
		public void ClearAndCleanTable(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void NewPlateIsReady() {
            throw new Exception("Not implemented");
        }

    }

}
