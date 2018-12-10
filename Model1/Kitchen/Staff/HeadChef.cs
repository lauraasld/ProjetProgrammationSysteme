using Model.DiningRoom;

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
            throw new System.Exception("Not implemented");
        }
        public void ChangeOrdersOrdering()
        {
            throw new System.Exception("Not implemented");
        }

    }

}
