namespace Model.Kitchen
{
    public class Dishwasher : KitchenStaff
    {
        public Dishwasher(Kitchen kitchen) : base(kitchen)
        {
        }

        public void FillDishwasher()
        {
            kitchen.DishwasherMachines[0].Wash();
        }
        public void EmptyDishwasher()
        {
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.DishwasherMachines[0].StoreCleanItems());
        }
        public void FillWashingMachine()
        {
            kitchen.WashingMachines[0].Wash();
        }
        public void EmptyWashingMachine()
        {
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.WashingMachines[0].StoreCleanItems());
        }
        public void WashToolsAtSink()
        {
            kitchen.Sinks[0].Wash();
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.Sinks[0].StoreCleanItems());
        }
    }

}
