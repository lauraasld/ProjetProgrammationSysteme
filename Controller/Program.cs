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
            new ControllerFacade();
            new ModelFacade();
            new ViewFacade();
            Console.WriteLine("Hello World!vd");
            Console.ReadLine();
        }
    }
}
