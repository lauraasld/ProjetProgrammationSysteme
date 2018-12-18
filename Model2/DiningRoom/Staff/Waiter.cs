using Microsoft.EntityFrameworkCore.Internal;
using Model.Kitchen;
using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom
{
    public class Waiter : DiningRoomStaff
    {
        private double timeMultiplier = 1;

        public Waiter(DiningRoom diningRoom) : base(diningRoom)
        {
            timeMultiplier = 1;
        }

        public void GiveBreadAndWater(int tableNumber)
        {
        }

        public void ServeFood(int tableNumber)
        {
            StartAction("Sert les plats à la table " + tableNumber, 2);
            Table tableToServe = diningRoom.Tables.Find(t => t.TableNumber == tableNumber);
            tableToServe.LastTimeOrderWasTakenCareOf = SimulationClock.GetInstance().SimulationDateTime;
            //List<Plate> platesReadyToServe = diningRoom.Countertop.PlatesToServe;
            //foreach (var plate in pTS)
            //{
            //    diningRoom.Countertop.Orders.First(x => x.Orders.Values.ToList()
            //    .ForEach(i => { if (i.DishName.Equals(plate.Dish.DishName) && x.CourseType.Equals(plate.Dish.CourseType)) { pTS.Remove(plate); } }));
            //}
            foreach (var order in tableToServe.OrderedDishes.Where(x => x.CourseType == tableToServe.NextCourseToServe))
            {
                lock (Countertop.LockObjPlatesToServe)
                {
                    foreach (var plat in diningRoom.Countertop.PlatesToServe)
                    {
                        if (order.DishName == plat.Dish.DishName)
                        {
                            tableToServe.ServedFood.Add(plat);
                            diningRoom.Countertop.PlatesToServe.Remove(plat);
                            break;
                        }
                    }
                }
            }
            tableToServe.NextCourseToServe++;
            EndAction();
            //Passer au CourseType suivant
        }
        // ne prend en compte que CourseType
        // les Comparer a la liste PlateToServe
        //Si ok -> remove de la liste PlateToServe + CourseType+=1

        public void ClearPlates(int tableNumber)
        {
            StartAction("Ramasse les plats à la table " + tableNumber, 1);
            Table tableToClear = diningRoom.Tables.Find(t => t.TableNumber == tableNumber);

            if (!tableToClear.ServedFood.Any(x => x.IsFinished == false))
            {
                diningRoom.Countertop.ItemsGoingToKitchen.AddRange(tableToClear.ServedFood);
                tableToClear.ServedFood.Clear();
            }
            //quand plat fini, alors débarasse IsReadyToServe == true
            EndAction();
        }

        public void ClearAndCleanTable(int tableNumber)
        {
            StartAction("Débarasse et nettoie la table " + tableNumber, 1);
            /*ClearPlates(tableNumber);
            diningRoom.Tables.Find(t => t.TableNumber == tableNumber).IsAvailable = true;*/
            EndAction();
        }

        public int FindTableReadyToBeServed()
        {
            StartAction("Vérifie si tous les plats sont prêts pour une table", 1);
            Table table = null;
            //List<Plate> platesReadyToServe = diningRoom.Countertop.PlatesToServe;
            lock (Countertop.LockObjPlatesToServe)
            {
                List<Plate> copyOfAvailablePlates = diningRoom.Countertop.PlatesToServe.ToList();
                if (copyOfAvailablePlates == null || copyOfAvailablePlates.Count == 0)
                {
                    EndAction();
                    return -1;
                }
                table = diningRoom.Countertop.Orders.OrderBy(x => x.LastTimeOrderWasTakenCareOf).First();

                foreach (var order in table.OrderedDishes.Where(x => x.CourseType == table.NextCourseToServe))
                {
                    //var plate = copyOfAvailablePlates.FirstOrDefault(x => x.Dish.DishName == order.DishName);
                    var plate = copyOfAvailablePlates.Where(kv => kv.Dish.DishName == order.DishName).DefaultIfEmpty().FirstOrDefault();
                    if (plate != null)
                    {
                        copyOfAvailablePlates.Remove(plate);
                    }
                    else
                    {
                        EndAction();
                        return -1;
                    }
                }
            }

            EndAction();
            return table.TableNumber;
        }

        // tester sitous les plats sont prets pour une des table, et renvoyer le numéro de la table
        // si oui, appelle ServeFood
    }
}


