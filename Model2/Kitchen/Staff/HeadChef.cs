using Model.DiningRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.Kitchen
{
    public class HeadChef : KitchenStaff
    {
        public HeadChef(Kitchen kitchen) : base(kitchen)
        {
        }

        public void PrepareMenus()
        {
            Menu menu = new Menu();
            foreach (DishName item in Enum.GetValues(typeof(DishName)))
            {
                menu.AvailableDishes.Add(new Dish(item, (CourseType)((int)item / 3)));
            }
            kitchen.Countertop.Menus.Add(menu);
        }
        public void StartCoursesOrderPreparation(Table tableOrder)
        {
            List<Dish> newDishesToPrepareNow = GetDishesToPrepareNow(tableOrder);
            foreach (Dish dish in newDishesToPrepareNow)
            {
                Console.WriteLine("A");
                Cook availableCook;
                do
                {
                    availableCook = kitchen.Cooks.Where(cook => cook.IsBusy == false).FirstOrDefault();
                } while (availableCook == null);
                availableCook.IsBusy = true;
                //ThreadPool.QueueUserWorkItem(AssignDishPreparationToCook, new { dish, availableCook });
                Console.WriteLine("B");
                ThreadPool.QueueUserWorkItem(x => AssignDishPreparationToCook(dish, availableCook));
                Console.WriteLine("C");
            }
        }

        private void AssignDishPreparationToCook(Dish dish, Cook availableCook)
        {
            if (Monitor.TryEnter(availableCook.lockObj, 500))
            {
                try
                {
                    availableCook.IsBusy = true;
                    availableCook.PrepareOrderedDish(dish);
                }
                finally
                {
                    availableCook.IsBusy = false;
                    Monitor.Exit(availableCook.lockObj);
                }
            }
            else
            {
                AssignDishPreparationToCook(dish, availableCook);
            }
        }

        private List<Dish> GetDishesToPrepareNow(Table tableOrder)
        {
            return tableOrder.OrderedDishes.Where(x => x.CourseType == tableOrder.NextCourseToServe).ToList();
        }

        public void ChangeOrdersOrdering()
        {
            throw new System.Exception("Not implemented");
        }

    }

}
