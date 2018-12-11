using System;
using System.Collections.Generic;

namespace Model.DiningRoom
{
    public class TableOrder
    {
        public int TableNumber { get; set; }
        public Dictionary<Customer, Dish> Orders { get; set; }
        public CourseType NextCourseToServe { get; set; }
        public DateTime LastTimeOrderWasTakenCareOf { get; set; }
    }
}
