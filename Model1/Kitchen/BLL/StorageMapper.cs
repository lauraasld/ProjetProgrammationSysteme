using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;
namespace Model.Kitchen.BLL {
	public class StorageMapper {
		public static StorageBusiness Map(StorageDao storage) {
            return new StorageBusiness
            {
                Id = storage.Id,
                ArrivalDate = storage.ArrivalDate,
                Amount = storage.Amount,
                Product = storage.Product != null ? ProductMapper.Map(storage.Product) : null
            };
        }
		public static StorageDao Map(StorageBusiness storage) {
            return new StorageDao
            {
                Id = storage.Id,
                ArrivalDate = storage.ArrivalDate,
                Amount = storage.Amount
            };
        }

        public static List<StorageBusiness> Map(List<StorageDao> storage)
        {
            return (from s in storage select Map(s)).ToList();
        }
    }

}
