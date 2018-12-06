using System; using System.Collections.Generic;
namespace Model.Kitchen.DAL {
	public class ProductDao {
		public int Id;
		public string Name { get; }
		public int CategoryId { get; }
		public CategoryDao Category;

	}

}
