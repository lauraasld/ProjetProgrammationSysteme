using System; using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Model.Kitchen {
	public class WashingAppliance : MajorAppliance  {
		private int defaultWashingTime;
		private int loadingTime;
		private int storingTime;

		public void Wash(int customWashingTime = -1) {
			throw new System.Exception("Not implemented");
		}
		private void StoreCleanItems() {
			throw new System.Exception("Not implemented");
		}

	}

}
