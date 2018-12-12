using System; using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom {
	public class Customer {
        public bool OrdersStarter { private set; get; }

		public bool OrdersMainCourse { private set; get; }

		public bool OrdersDessert { private set; get; }


        public Menu menu { set; get; }

		private double timeMultiplier = 1;

        static Random rnd = new Random();

        public Customer(bool ordersStarter, bool ordersDish, bool ordersDessert, double timeMultiplier)
        {
            OrdersStarter = ordersStarter;
            OrdersMainCourse = ordersDish;
            OrdersDessert = ordersDessert;
            this.timeMultiplier = timeMultiplier;
        }
                    
        public void ChooseRecipes(Menu menu, List<Dish> OrderedDishes) {
                    
            if (OrdersStarter == true)
            {
                var listStarters = menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.Starter);
                int r = rnd.Next(listStarters.Count());
                OrderedDishes.Add(listStarters.ToList()[r]);
            }
            if (OrdersMainCourse == true)
            {
                var listMainCourse = menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.MainCourse);
                int r = rnd.Next(listMainCourse.Count());
                OrderedDishes.Add(listMainCourse.ToList()[r]);
            }
            if (OrdersDessert == true)
            {
                var listDesserts = menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.Dessert);
                int r = rnd.Next(listDesserts.Count());
                OrderedDishes.Add(listDesserts.ToList()[r]);
            }
        }

		public bool EatFood(Plate plate) {
            return plate.IsFinished == true;
		}

	}

}
