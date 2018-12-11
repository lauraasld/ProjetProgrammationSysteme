using Model;
using System;
using View;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ModelFacade model = new ModelFacade(2, 2, 1, 2, 2);
            ViewFacade view = new ViewFacade(model, null);
            new ControllerFacade(model, view);
            var v = new Model.DiningRoom.TableOrder();
            v.Orders.Add(new Model.DiningRoom.Customer(), new Model.DiningRoom.Dish(Model.DiningRoom.DishName.ConfitDeCanard, Model.DiningRoom.CourseType.Starter));
            model.Kitchen.HeadChef.StartCoursesOrderPreparation(v);
            Console.WriteLine("Hello World!vd");
            Console.ReadLine();
        }
    }
}
