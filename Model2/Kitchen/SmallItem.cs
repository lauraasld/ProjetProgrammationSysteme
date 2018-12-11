using System; using System.Collections.Generic;
namespace Model.Kitchen {
	public class SmallItem {
		public string Name;
		public bool IsClean { get; set; }
		public int WashingTime { get; }
		public SmallItemType ItemType;

        public SmallItem(string name, bool isClean, int washingTime, SmallItemType itemType)
        {
            Name = name;
            IsClean = isClean;
            WashingTime = washingTime;
            ItemType = itemType;
        }
    }

}
