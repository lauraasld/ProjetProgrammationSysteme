using System.ComponentModel.DataAnnotations.Schema;
namespace Model.Kitchen.DAL {
	public class CategoryDao {
		public int Id;
		public string Name { get; set; }
		public int TimeAlive { get; set; }

	}

}
