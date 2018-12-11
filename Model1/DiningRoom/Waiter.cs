using System; using System.Collections.Generic;
using System.Threading;

namespace Model.DiningRoom {
	public class Waiter : DiningRoomStaff , IPlatesToServeObserver  {
        private double timeMultiplier = 1;
        public Waiter(DiningRoom diningRoom) : base(diningRoom)
        {            
            this.timeMultiplier = timeMultiplier;
        }
        public void GiveBreadAndWater(int tableNumber) {
        }
		public void ServeFood(int tableNumber) {
            foreach (var item in diningRoom.Tables)
            {
                if (item.TableNumber == tableNumber)
                {

                }
            }
            //récupère la liste table order
            // ne prend en compte que CourseType
            // les Comparer a la liste PlateToServe
            //Si ok -> remove de la liste PlateToServe + CourseType+=1
        }
		public void ClearPlates(int tableNumber) {
			//quand plat fini, alors débarasse IsReadyToServe == true
		}
		public void ClearAndCleanTable(int tableNumber) {
			throw new Exception("Not implemented");
		}
		public void NewPlateIsReady() {
			throw new Exception("Not implemented");
		}

	}

}
