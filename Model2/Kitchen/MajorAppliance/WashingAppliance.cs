using System.Collections.Generic;
using System.Threading;

namespace Model.Kitchen
{
    public class WashingAppliance : MajorAppliance
    {
        private int defaultWashingTime;
        private int loadingTime;
        private int storingTime;

        public WashingAppliance(int defaultWashingTime, int loadingTime, int storingTime)
        {
            this.defaultWashingTime = defaultWashingTime;
            this.loadingTime = loadingTime;
            this.storingTime = storingTime;
        }

        public void Wash(int customWashingTime = -1)
        {
            StoredItems = Queue;
            Queue.Clear();
            Thread.Sleep(customWashingTime == -1 ? defaultWashingTime * ModelFacade.MinuteToMilisecondsMultiplier : customWashingTime * ModelFacade.MinuteToMilisecondsMultiplier);
            foreach (SmallItem item in StoredItems)
            {
                item.IsClean = true;
            }
        }
        public List<SmallItem> StoreCleanItems()
        {
            Thread.Sleep(storingTime * ModelFacade.MinuteToMilisecondsMultiplier);
            List<SmallItem> i = StoredItems;
            StoredItems.Clear();
            return i;
        }
    }
}
