using System;
namespace Kitchen.DAL and BLL {
	public class ProductDao {
		public int Id;
		public string Name { get; }
		public int CategoryId { get; }
		public CategoryDao Category;

	}

}
