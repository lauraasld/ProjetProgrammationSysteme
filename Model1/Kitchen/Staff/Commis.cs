using Model.DiningRoom;
namespace Model.Kitchen
{
    public class Commis : KitchenStaff
    {
        public Commis(Kitchen kitchen) : base(kitchen)
        {
        }

        public Product RetreiveProductFromStorage(string productName)
        {
            return kitchen.ProductStorage.RetreiveProduct(productName);
        }
        public void BringPlateToCountertop(Plate plate)
        {
            kitchen.Countertop.PlatesToServe.Add(plate);
        }
        public void ExecuteTask()
        {
            throw new System.Exception("Not implemented");
        }
        public void BringToolToSink(SmallItem item)
        {
            kitchen.Sinks[0].Queue.Add(item);
        }

    }

}
