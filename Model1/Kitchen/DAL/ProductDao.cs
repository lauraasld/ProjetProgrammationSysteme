using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL {
	public class ProductDao {
		public int Id;
		public string Name { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryDao Category { get; set; }

    }

}
