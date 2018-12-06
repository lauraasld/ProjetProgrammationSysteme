using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL {
	public class CategoryMapper {
		public static CategoryBusiness Map(CategoryDao category) {
            return new CategoryBusiness
            {
                Id = category.Id,
                Name = category.Name,
                TimeAlive = category.TimeAlive
            };
        }
		public static CategoryDao Map(CategoryBusiness category) {
            return new CategoryDao
            {
                Id = category.Id,
                Name = category.Name,
                TimeAlive = category.TimeAlive
            };
        }
        public static List<CategoryBusiness> Map(List<CategoryDao> category)
        {
            return (from c in category select Map(c)).ToList();
        }
    }

}
