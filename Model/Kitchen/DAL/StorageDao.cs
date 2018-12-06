using System; using System.Collections.Generic;
namespace Model.Kitchen.DAL {
	public class StorageDao {
		public int Id;
		public DateTime ArrivalDate { get; }
		public int Amount { get; }
		public int ProductId;
		public ProductDao Product;

	}

}
