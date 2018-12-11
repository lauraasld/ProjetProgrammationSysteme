namespace Model.Kitchen
{
    public abstract class KitchenStaff : Staff
    {
        protected Kitchen kitchen;

        protected KitchenStaff(Kitchen kitchen)
        {
            this.kitchen = kitchen;
        }
    }

}
