using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class MajorAppliance {
		public List<SmallItem> Queue;
		public List<SmallItem> StoredItems;

		public void AddToQueue(SmallItem item) {
			throw new System.Exception("Not implemented");
		}

	}

}