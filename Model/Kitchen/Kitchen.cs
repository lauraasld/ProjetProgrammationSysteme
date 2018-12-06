using System;
namespace Kitchen {
	public class Kitchen {
		public Countertop Countertop { get; }
		public List<Fridge> Fridges { get; }
		public List<Oven> Ovens { get; }
		public List<Hotplate> Hotplates { get; }
		public List<DishwasherMachine> DishwasherMachines { get; }
		public List<WashingMachine> WashingMachine { get; }
		public List<Restaurant.Kitchen.Sinks> Sinks { get; }

		private Fridge fridge;
		private Oven oven;
		private Hotplate hotplate;
		private DishwasherMachine dishwasherMachine;
		private Sink sink;

	}

}
