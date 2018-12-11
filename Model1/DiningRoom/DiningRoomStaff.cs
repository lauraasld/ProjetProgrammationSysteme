using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public abstract class DiningRoomStaff : Staff  {
		private DiningRoom diningRoom;

        protected DiningRoomStaff(DiningRoom diningRoom)
        {
            this.diningRoom = diningRoom;
        }
    }

}
