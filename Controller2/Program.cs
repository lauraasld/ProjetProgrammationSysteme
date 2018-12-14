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
            Console.WriteLine("Hello World!vd");
            Console.ReadLine();
        }
    }
}
