using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class Cook : KitchenStaff  {
		public void PrepareDishesForLater(Dictionary<DiningRoom.Dish, int> amountByDishes) {
			throw new System.Exception("Not implemented");
		}
		public void PrepareOrderedDish(DiningRoom.Dish dish) {
			throw new System.Exception("Not implemented");
		}
		private void AssignTaskToCommis() {
			throw new System.Exception("Not implemented");
		}
		private Product RetreiveProductFromStorage(string productName) {
			throw new System.Exception("Not implemented");
		}
		private void GetTool(SmallItemType tool) {
			throw new System.Exception("Not implemented");
		}

	}

}
