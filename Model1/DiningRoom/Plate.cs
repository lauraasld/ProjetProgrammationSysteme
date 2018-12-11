namespace Model.DiningRoom
{
    public class Plate : Kitchen.SmallItem
    {
        public bool IsFinished { get; set; }
        public bool IsReadyToServe { get; set; }
        public Dish Dish { get; set; }

        public Plate(bool isFinished, bool isReadyToServe, Dish dish) : base(dish.DishName.ToString(), false, 1, Kitchen.SmallItemType.Plate)
        {
            IsFinished = isFinished;
            IsReadyToServe = isReadyToServe;
            Dish = dish;
        }

    }

}
