namespace Model.Kitchen
{
    public abstract class KitchenStaff : Person
    {
        protected Kitchen kitchen;

        protected KitchenStaff(Kitchen kitchen) : base()
        {
            this.kitchen = kitchen;
        }
    }

}
