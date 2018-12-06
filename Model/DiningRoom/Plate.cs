using System;
namespace DiningRoom {
	public class Plate : Kitchen.SmallItem  {
		public bool IsFinished { get; set; }
		public bool IsReadyToServe { get; set; }
		public Dish Dish;

		private Dish dish;

	}

}
