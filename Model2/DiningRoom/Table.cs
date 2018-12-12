using Model.Kitchen;
using System;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Table
    {
        private static int totalNumberOfTables = 0;

        public int TableNumber { get; set; }

        public int Square { get; set; }

        public int Row { get; set; }

        public List<Place> Places { get; private set; }

        public bool IsBooked { get; set; }

        public bool IsAvailable { get; set; }
        //public SmallItem Tablecloth { get; set; }

        public DateTime LastTimeOrderWasTakenCareOf { get; set; }
                            
        public Table(int square, int row, int numberOfPlaces, bool isBooked = false)
        {
            TableNumber = totalNumberOfTables++;
            Row = row;
            Square = square;
            Places = new List<Place>();
            for (int i = 0; i < numberOfPlaces; i++)
            {
                Places.Add(new Place());
            }
            IsBooked = isBooked;
        }

    }

}
