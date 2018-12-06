using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class SmallItem {
		public String Name;
		public bool IsClean { get; set; }
		public int WashingTime { get; }
		public SmallItemType ItemType;


		private SmallItemType smallItemType;

	}

}
