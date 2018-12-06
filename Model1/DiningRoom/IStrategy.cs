using System; using System.Collections.Generic;
namespace Model.DiningRoom {
	public interface IStrategy {
		Dish ChooseRecipe(Menu menu);

	}

}
