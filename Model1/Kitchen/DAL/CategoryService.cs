using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Model.Kitchen.DAL;

namespace Model.Kitchen.DAL
{
    public class CategoryService
    {
        DatabaseContext databaseContext;
        public CategoryService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(CategoryBusiness Category)
        {
            var entity = CategoryMapper.Map(Category);
            databaseContext.Category.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(CategoryBusiness Category)
        {
            var entity = databaseContext.Category.Find(Category.Id);
            if (entity != null)
            {
                entity = CategoryMapper.Map(Category);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from c in databaseContext.Category where c.Id == id select c).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Category.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<CategoryBusiness> GetAll()
        {
            return (from c in databaseContext.Category select CategoryMapper.Map(c)).ToList();
        }
        public CategoryBusiness Get(int id)
        {
            return (from c in databaseContext.Category where c.Id == id select CategoryMapper.Map(c)).FirstOrDefault();
        }
    }

}
