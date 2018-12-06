using System; using System.Collections.Generic;
namespace Model.Kitchen.BLL {
	public class StorageBusiness {
		public int Id;
		public DateTime ArrivalDate { get; }
		public int Amount { get; }
		public ProductBusiness Product;

	}

}
