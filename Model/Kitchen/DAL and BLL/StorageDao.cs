using System;
namespace Kitchen.DAL and BLL {
	public class StorageDao {
		public int Id;
		public DateTime ArrivalDate { get; }
		public int Amount { get; }
		public int ProductId;
		public ProductDao Product;

	}

}
