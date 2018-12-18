using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public struct Dish {
		public DishName DishName;
		public CourseType CourseType;

        public Dish(DishName dishName, CourseType courseType)
        {
            DishName = dishName;
            CourseType = courseType;
        }
    }

}
