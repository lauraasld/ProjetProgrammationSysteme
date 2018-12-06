using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public class Customer {
		public string Name;
		public bool OrdersStarter { get; }
		public bool OrdersDish { get; }
		public bool OrdersDessert { get; }
		public double TimeMultiplier;
		private IStrategy chooseRecipeStrategy;

		public Dish ChooseRecipe(Menu menu) {
			throw new System.Exception("Not implemented");
		}
		public void EatFood(Plate plate) {
			throw new System.Exception("Not implemented");
		}
		public void Pay() {
			throw new System.Exception("Not implemented");
		}

		private IStrategy iStrategy;


	}

}
