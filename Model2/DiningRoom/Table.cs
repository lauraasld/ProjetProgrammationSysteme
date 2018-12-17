using Model.Kitchen;
using System;
using System.Collections.Generic;
namespace Model.DiningRoom
{
    public class Table
    {
        public static int totalNumberOfTables = 0;

        public int TableNumber { get; set; }

        public int Square { get; set; }

        public int Row { get; set; }

        public int NumberOfPlaces { get; set; }

        public List<Customer> SeatedCustomers { get; set; }

        public List<Plate> ServedFood { get; private set; }

        public List<Dish> OrderedDishes { get; private set; }

        public CourseType NextCourseToServe { get; set; }

        public bool IsBooked { get; set; }

        public bool IsAvailable { get; set; }
        public int NumberOfSeatedCustomers { get; set; }
        //public SmallItem Tablecloth { get; set; }

        public DateTime LastTimeOrderWasTakenCareOf { get; set; }
                            
        public Table(int square, int row, int numberOfPlaces, bool isBooked = false)
        {
            totalNumberOfTables++;
            TableNumber = totalNumberOfTables;
            Row = row;
            Square = square;
            NumberOfPlaces = numberOfPlaces;
            SeatedCustomers = new List<Customer>();
            ServedFood = new List<Plate>();
            OrderedDishes = new List<Dish>();
            IsBooked = isBooked;
            IsAvailable = true;
        }

    }

}
