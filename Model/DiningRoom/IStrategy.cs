using System;
namespace DiningRoom {
	public interface IStrategy {
		Dish ChooseRecipe(ref Menu menu);

	}

}
