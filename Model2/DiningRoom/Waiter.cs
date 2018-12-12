using System; using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.DiningRoom {
	public class Waiter : DiningRoomStaff , IPlatesToServeObserver  {
        private double timeMultiplier = 1;
        public Kitchen.Countertop plateToServe;

        public Waiter(DiningRoom diningRoom) : base(diningRoom)
        {            
            this.timeMultiplier = 1;
        }
        public void GiveBreadAndWater(int tableNumber) {
        }

		public void ServeFood(int tableNumber) {
            
            foreach (var item in diningRoom.Tables)
            {
                List<Plate> pTS = plateToServe.PlatesToServe;
                List<TableOrder> orders = plateToServe.Orders;

                if (item.TableNumber == tableNumber)
                { 
                    foreach (var order in orders)
                    {
                        List<Dish> ordersDish = order.Orders.Values.ToList();
                        foreach(var orderDish in ordersDish)
                        {
                            foreach (var plate in pTS)
                            {
                                if (orderDish.DishName.Equals(plate.Name) /*&& orderDish.CourseType.Equals(plate.courseType)*/)
                                {
                                    pTS.Remove(plate);
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
