namespace Model.DiningRoom
{

    public abstract class DiningRoomStaff : Person
    {
        protected DiningRoom diningRoom;

        protected DiningRoomStaff(DiningRoom diningRoom) : base()
        {
            this.diningRoom = diningRoom;
        }
    }

}
