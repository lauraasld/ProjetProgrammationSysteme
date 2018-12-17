using Model;
using System;
using View;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.ComponentModel;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console debug du controller");
            ModelFacade model = new ModelFacade(2, 2, 1, 2, 2);
            ViewFacade view = new ViewFacade(model);
            //view.RefreshLists
            new ControllerFacade(model, view);
            ActionsListService actionsListService = new ActionsListService();
            List<ActionsListBusiness> testBDD = actionsListService.GetByScenario(1);
            Console.WriteLine(testBDD[0].Scenario.Title + " est composé de " + testBDD.Count + " actions.");
           // var v = new Model.DiningRoom.TableOrder();
            //v.Orders.Add(new Model.DiningRoom.Customer(true, true, true, 1), new Model.DiningRoom.Dish(Model.DiningRoom.DishName.ConfitDeCanard, Model.DiningRoom.CourseType.Starter));
           // model.Kitchen.HeadChef.StartCoursesOrderPreparation(v);
            Console.ReadLine();
        }
    }
}
