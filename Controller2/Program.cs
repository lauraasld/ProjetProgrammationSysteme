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
            new ControllerFacade(model, view);
            Console.ReadLine();
        }
    }
}
