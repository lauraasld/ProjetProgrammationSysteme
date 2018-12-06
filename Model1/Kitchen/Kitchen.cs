using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class Kitchen {
		public Countertop Countertop { get; }
		public List<Fridge> Fridges { get; }
		public List<Oven> Ovens { get; }
		public List<Hotplate> Hotplates { get; }
		public List<DishwasherMachine> DishwasherMachines { get; }
		public List<WashingMachine> WashingMachine { get; }
		public List<Sink> Sinks { get; }

	}

}