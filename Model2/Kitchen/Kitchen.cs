using System.Collections.Generic;

namespace Model.Kitchen
{
    public class Kitchen
    {
        public Countertop Countertop { private set; get; }

        public List<BakingAppliance> BakingAppliances { private set; get; }
        public List<WashingAppliance> WashingAppliances { private set; get; }

        public HeadChef HeadChef { get; private set; }
        public List<Cook> Cooks { get; private set; }
        public List<Commis> Commis { get; private set; }
        public List<Dishwasher> Dishwashers { get; private set; }
        //public ProductStorageFacade ProductStorage { get; set; }

        /*public List<Fridge> Fridges { private set; get; }
        public List<Oven> Ovens { private set; get; }
        public List<Hotplate> Hotplates { private set; get; }
        public List<DishwasherMachine> DishwasherMachines { private set; get; }
        public List<WashingMachine> WashingMachines { private set; get; }
        public List<Sink> Sinks { private set; get; }*/

        public Kitchen(int nbOfCooks, int nbOfCommis, int nbOfDishwashers)
        {
            Cooks = new List<Cook>();
            Commis = new List<Commis>();
            Dishwashers = new List<Dishwasher>();
            Countertop = new Countertop();
            BakingAppliances = new List<BakingAppliance>();
            BakingAppliances.Add(new BakingAppliance());
            WashingAppliances = new List<WashingAppliance>();
            WashingAppliances.Add(new WashingAppliance(2,1,1));
            HeadChef = new HeadChef(this);
            for (int i = 0; i < nbOfCooks; i++)
                Cooks.Add(new Cook(this));
            for (int i = 0; i < nbOfCommis; i++)
                Commis.Add(new Commis(this));
            for (int i = 0; i < nbOfDishwashers; i++)
                Dishwashers.Add(new Dishwasher(this));
            /*Ovens = new List<Oven>();
            Hotplates = new List<Hotplate>();
            DishwasherMachines = new List<DishwasherMachine>();
            WashingMachines = new List<WashingMachine>();
            Sinks = new List<Sink>();*/
        }
    }
}
