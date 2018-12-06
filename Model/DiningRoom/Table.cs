using System;
namespace DiningRoom {
	public class Table {
		public int TableNumber;
		public int Row;
		public int Square;
		public List<Place> Places;
		public bool IsBooked;
		public Tableware Tablecloth { get; set; }

		private Place place;


	}

}
