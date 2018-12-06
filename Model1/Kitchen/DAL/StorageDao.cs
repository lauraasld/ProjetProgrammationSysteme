using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL {
	public class StorageDao {
		public int Id;
		public DateTime ArrivalDate { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductDao Product { get; set; }

    }

}
