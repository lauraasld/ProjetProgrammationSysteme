using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public abstract class DiningRoomStaff : Staff  {
		protected DiningRoom diningRoom;

        protected DiningRoomStaff(DiningRoom diningRoom)
        {
            this.diningRoom = diningRoom;
        }
    }

}
