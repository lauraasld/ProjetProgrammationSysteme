using System;
using System.Collections.Generic;
using Model.Kitchen.DAL;
using Model.Kitchen.BLL;


namespace TestConnexionBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            ComposeService composeService = new ComposeService();
            List<ComposeBusiness> plop = composeService.GetByScenario(1);
            foreach (var item in plop)
            {
                Console.WriteLine("Scénario : " + item.Scenario.Title);
                Console.WriteLine("Action : " + item.Action.Name);
                Console.WriteLine("Fait par : " + item.Action.Person.Role);
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
