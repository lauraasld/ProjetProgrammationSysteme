using System; using System.Collections.Generic;
namespace Model.Kitchen.BLL {
	public class ProductBusiness {
		public int Id;
		public string Name { get; set; }
		public CategoryBusiness Category { get; set; }

	}

}
