using Model.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.DiningRoom
{
    public class Waiter : DiningRoomStaff, IPlatesToServeObserver
    {
        private double timeMultiplier = 1;
        public Waiter(DiningRoom diningRoom) : base(diningRoom)
        {
            this.timeMultiplier = 1;
        }
        public void GiveBreadAndWater(int tableNumber)
        {
        }

        public void ServeFood(int tableNumber)
        {
            Table tableToServe = diningRoom.Tables.Find(t => t.TableNumber == tableNumber);
            List<Plate> platesReadyToServe = diningRoom.Countertop.PlatesToServe;

            //foreach (var plate in pTS)
            //{
            //    diningRoom.Countertop.Orders.First(x => x.Orders.Values.ToList()
            //    .ForEach(i => { if (i.DishName.Equals(plate.Dish.DishName) && x.CourseType.Equals(plate.Dish.CourseType)) { pTS.Remove(plate); } }));
            //}
            foreach (var order in tableToServe.OrderedDishes.Where(x => x.CourseType == tableToServe.NextCourseToServe))
            {
                foreach (var plat in platesReadyToServe)
                {
                    if (order.DishName == plat.Dish.DishName)
                    {
                        tableToServe.ServedFood.Add(plat);
                        platesReadyToServe.Remove(plat);
                        break;
                    }
                }
            }
            tableToServe.NextCourseToServe++;
            //Passer au CourseType suivant
        }
        // ne prend en compte que CourseType
        // les Comparer a la liste PlateToServe
        //Si ok -> remove de la liste PlateToServe + CourseType+=1

        public void ClearPlates(int tableNumber)
        {
            Table tableToClear = diningRoom.Tables.Find(t => t.TableNumber == tableNumber);

            if (!tableToClear.ServedFood.Any(x => x.IsFinished == false))
            {
                diningRoom.Countertop.ItemsGoingToKitchen.AddRange(tableToClear.ServedFood);
                tableToClear.ServedFood.Clear();
            }
            //quand plat fini, alors débarasse IsReadyToServe == true
        }
        public void ClearAndCleanTable(int tableNumber)
        {
            diningRoom.Tables.Find(t => t.TableNumber == tableNumber).IsAvailable = true;
        }
        public void NewPlateIsReady()
        {
            // tester sitous les plats sont prets pour une des table
            // si oui, appelle ServeFood
            throw new Exception("Not implemented");
        }

    }

}
