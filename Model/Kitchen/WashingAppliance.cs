using System;
using System.Runtime.InteropServices;
namespace Kitchen {
	public class WashingAppliance : MajorAppliance  {
		private int defaultWashingTime;
		private int loadingTime;
		private int storingTime;

		public void Wash([Optional, DefaultParameterValueAttribute(-1 : int)]ref object customWashingTime) {
			throw new System.Exception("Not implemented");
		}
		private void StoreCleanItems() {
			throw new System.Exception("Not implemented");
		}

	}

}
