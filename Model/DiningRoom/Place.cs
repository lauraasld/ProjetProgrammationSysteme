using System;
namespace DiningRoom {
	public class Place {
		public List<Kitchen.SmallItem> Tableware;
		public Customer SeatedCustomer;
		public Plate CookedFood { get; set; }

		private Plate plate;
		private Customer customer;


	}

}
