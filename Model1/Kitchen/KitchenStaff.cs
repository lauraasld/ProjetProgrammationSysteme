using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public abstract class KitchenStaff : PositionedElement  {
		protected Kitchen kitchen;

        protected KitchenStaff(Kitchen kitchen)
        {
            this.kitchen = kitchen;
        }
    }

}
