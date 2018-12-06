using System;
namespace Kitchen {
	public abstract class ItemFactory {
		public static SmallItem CreateKitchenKnife() {
			throw new System.Exception("Not implemented");
		}
		public static SmallItem CreateWineGlass() {
			throw new System.Exception("Not implemented");
		}
		public static SmallItem CreateBlender() {
			throw new System.Exception("Not implemented");
		}

	}

}
