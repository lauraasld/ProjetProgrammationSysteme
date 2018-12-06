using System;
namespace Kitchen.DAL and BLL {
	public class StorageBusiness {
		public int Id;
		public DateTime ArrivalDate { get; }
		public int Amount { get; }
		public ProductBusiness Product;

	}

}
