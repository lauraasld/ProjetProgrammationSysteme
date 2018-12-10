using System.Collections.Generic;

namespace Model.Kitchen
{
    public class Kitchen
    {
        public Countertop Countertop { private set; get; }
        public ProductStorageFacade ProductStorage { get; set; }

        public List<Fridge> Fridges { private set; get; }
        public List<Oven> Ovens { private set; get; }
        public List<Hotplate> Hotplates { private set; get; }
        public List<DishwasherMachine> DishwasherMachines { private set; get; }
        public List<WashingMachine> WashingMachines { private set; get; }
        public List<Sink> Sinks { private set; get; }


        public Kitchen()
        {
            Countertop = new Countertop();
            ProductStorage = new ProductStorageFacade();
            Fridges = new List<Fridge>();
            Ovens = new List<Oven>();
            Hotplates = new List<Hotplate>();
            DishwasherMachines = new List<DishwasherMachine>();
            WashingMachines = new List<WashingMachine>();
            Sinks = new List<Sink>();
        }
    }
}
