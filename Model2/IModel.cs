namespace Model
{
    public interface IModel
    {
        DiningRoom.DiningRoom DiningRoom { get; }
        Kitchen.Kitchen Kitchen { get; }
    }
}
