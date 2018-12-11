using Model.DiningRoom;
using System.Collections.Generic;
using System.Linq;

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
        public void AssignTasksToCookers(TableOrder tableOrder)
        {
            foreach (Dish dish in GetDishesToPrepareNow(tableOrder))
            {
                
            }
        }

        private List<Dish> GetDishesToPrepareNow(TableOrder tableOrder)
        {
            return tableOrder.Orders.Where(x => x.Value.CourseType == tableOrder.NextCourseToServe).ToDictionary(i => i.Key, i => i.Value).Values.ToList();
        }

        public void ChangeOrdersOrdering()
        {
            throw new System.Exception("Not implemented");
        }

    }

}
