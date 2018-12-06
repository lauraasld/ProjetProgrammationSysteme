using Model.Kitchen;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Table
    {
        public int TableNumber;
        public int Row;
        public int Square;
        public List<Place> Places;
        public bool IsBooked;
        public SmallItem Tablecloth { get; set; }

        private Place place;


    }

}
