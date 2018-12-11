namespace Model.Kitchen
{
    public class Dishwasher : KitchenStaff
    {
        public Dishwasher(Kitchen kitchen) : base(kitchen)
        {
        }

        public void FillDishwasher()
        {
            kitchen.WashingAppliances[0].Wash();
        }
        public void EmptyDishwasher()
        {
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.WashingAppliances[0].StoreCleanItems());
        }
        public void FillWashingMachine()
        {
            kitchen.WashingAppliances[0].Wash();
        }
        public void EmptyWashingMachine()
        {
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.WashingAppliances[0].StoreCleanItems());
        }
        public void WashToolsAtSink()
        {
            kitchen.WashingAppliances[0].Wash();
            kitchen.Countertop.KitchenwareStorage.AddRange(kitchen.WashingAppliances[0].StoreCleanItems());
        }
    }

}
