using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DiningRoom
{
    public class Customer : Person
    {
        public bool OrdersStarter { private set; get; }

        public bool OrdersMainCourse { private set; get; }

        public bool OrdersDessert { private set; get; }


        public Menu Menu { set; get; }

        private static Random rnd = new Random();

        public Customer(double timeMultiplier = 1) : base()
        {
            OrdersStarter = false;
            OrdersMainCourse = false;
            OrdersDessert = false;
            TimeMultiplier = timeMultiplier;
        }

        public Customer(bool ordersStarter, bool ordersDish, bool ordersDessert, double timeMultiplier) : base()
        {
            OrdersStarter = ordersStarter;
            OrdersMainCourse = ordersDish;
            OrdersDessert = ordersDessert;
            TimeMultiplier = timeMultiplier;
        }

        public void ChooseRecipes(List<Dish> OrderedDishes)
        {
            StartAction("Choix du menu", 1);
            if (OrdersStarter == true)
            {
                var listStarters = Menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.Starter);
                int r = rnd.Next(listStarters.Count());
                OrderedDishes.Add(listStarters.ToList()[r]);
            }
            if (OrdersMainCourse == true)
            {
                var listMainCourse = Menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.MainCourse);
                int r = rnd.Next(listMainCourse.Count());
                OrderedDishes.Add(listMainCourse.ToList()[r]);
            }
            if (OrdersDessert == true)
            {
                var listDesserts = Menu.AvailableDishes.Where(Dish => Dish.CourseType == CourseType.Dessert);
                int r = rnd.Next(listDesserts.Count());
                OrderedDishes.Add(listDesserts.ToList()[r]);
            }
            EndAction();
        }

        public void EatFood(Plate plate)
        {
            StartAction("Déguste le plat " + plate.Dish.DishName, 15);
            plate.IsFinished = true;
            EndAction();
        }

    }

}
