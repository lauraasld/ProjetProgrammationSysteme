using Model.Kitchen;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Table
    {
        public int TableNumber { get; }
        public int Row;
        public int Square;
        public List<Place> Places;
        public bool IsBooked;
        public bool IsAvailable;
        public SmallItem Tablecloth { get; set; }


    }

}
