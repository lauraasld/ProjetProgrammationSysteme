using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL {
    public class ProductMapper
    {
        public static ProductBusiness Map(ProductDao product)
        {
            return new ProductBusiness
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category != null ? CategoryMapper.Map(product.Category) : null
            };
        }
        public static ProductDao Map(ProductBusiness product)
        {
            return new ProductDao
            {
                Id = product.Id,
                Name = product.Name
            };
        }
        public static List<ProductBusiness> Map(List<ProductDao> product)
        {
            return (from p in product select Map(p)).ToList();
        }
    }
}
