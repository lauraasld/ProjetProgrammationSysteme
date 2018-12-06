using System; using System.Collections.Generic;
namespace Model.Kitchen.BLL {
	public class StorageBusiness {
		public int Id;
		public DateTime ArrivalDate { get; set; }
		public int Amount { get; set; }
		public ProductBusiness Product;

	}

}
