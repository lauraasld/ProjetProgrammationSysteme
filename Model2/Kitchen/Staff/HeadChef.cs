using Model.DiningRoom;
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
            throw new System.Exception("Not implemented");
        }
        public void StartCoursesOrderPreparation(Table tableOrder)
        {
            //foreach (Dish dish in GetDishesToPrepareNow(tableOrder))
            //{
            //    Cook availableCook;
            //    do
            //    {
            //        availableCook = kitchen.Cooks.Where(cook => cook.IsBusy == false).FirstOrDefault();
            //    } while (availableCook == null);
            //    //ThreadPool.QueueUserWorkItem(AssignDishPreparationToCook, new { dish, availableCook });
            //    ThreadPool.QueueUserWorkItem(x => AssignDishPreparationToCook(dish, availableCook));
            //}
        }

        private void AssignDishPreparationToCook(Dish dish, Cook availableCook)
        {
            /*Dish dish = state.dish;
            Cook availableCook;*/
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
            return tableOrder.Orders.Where(x => x.Value.CourseType == tableOrder.NextCourseToServe).ToDictionary(i => i.Key, i => i.Value).Values.ToList();
        }

        public void ChangeOrdersOrdering()
        {
            throw new System.Exception("Not implemented");
        }

    }

}
