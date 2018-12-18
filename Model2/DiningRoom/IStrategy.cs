using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public interface IStrategy {
		List<Dish> ChooseRecipe(Menu menu, bool ordersStarter, bool ordersDish, bool ordersDessert);

	}

}
