using System;
namespace Kitchen {
	public class Cook : KitchenStaff  {
		public void PrepareDishesForLater(ref Dictionnary<DiningRoom.Dish, Int> amountByDishes) {
			throw new System.Exception("Not implemented");
		}
		public void PrepareOrderedDish(ref DiningRoom.Dish dish) {
			throw new System.Exception("Not implemented");
		}
		private void AssignTaskToCommis() {
			throw new System.Exception("Not implemented");
		}
		private Product RetreiveProductFromStorage(ref string productName) {
			throw new System.Exception("Not implemented");
		}
		private void GetTool(ref SmallItemType tool) {
			throw new System.Exception("Not implemented");
		}

	}

}
