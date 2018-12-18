using Model.DiningRoom;
using System.Collections.Generic;
using System.Threading;

namespace Model.Kitchen
{
    public class Cook : KitchenStaff
    {
        //public Dish? DishBeingPrepared { get; private set; }

        public Cook(Kitchen kitchen) : base(kitchen)
        {
        }

        public void PrepareDishesForLater(Dictionary<Dish, int> amountByDishes)
        {
            foreach (KeyValuePair<Dish, int> dishes in amountByDishes)
            {
                for (int i = 1; i <= dishes.Value; i++)
                {
                    PrepareOrderedDish(dishes.Key);
                }
            }
        }

        internal void PrepareOrderedDish(Dish dish)
        {
            StartAction("Prépare le plat " + dish.DishName, 5);
            //DishBeingPrepared = dish;
            //Thread.Sleep((int)dish.DishName * ModelFacade.MinuteToMilisecondsMultiplier);
            lock (Countertop.LockObjPlatesToServe)
            {
                kitchen.Countertop.PlatesToServe.Add(new Plate(false, true, dish));
            }
            //DishBeingPrepared = null;
            EndAction();
        }

        private void AssignTaskToCommis()
        {
            throw new System.Exception("Not implemented");
        }
        /*private Product RetreiveProductFromStorage(string productName)
        {
            return kitchen.ProductStorage.RetreiveProduct(productName);
        }*/
        private void GetTool(SmallItemType tool)
        {
            throw new System.Exception("Not implemented");
        }

    }

}
