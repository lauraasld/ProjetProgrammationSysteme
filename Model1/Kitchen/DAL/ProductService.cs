using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Model.Kitchen.DAL;

namespace Model.Kitchen.DAL
{
    public class ProductService
    {
        DatabaseContext databaseContext;
        public ProductService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ProductBusiness Product)
        {
            var entity = ProductMapper.Map(Product);
            databaseContext.Product.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ProductBusiness Product)
        {
            var entity = databaseContext.Product.Find(Product.Id);
            if (entity != null)
            {
                entity = ProductMapper.Map(Product);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Product where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Product.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ProductBusiness> GetAll()
        {
            return (from s in databaseContext.Product.Include(i => i.Category) select ProductMapper.Map(s)).ToList();
        }
        public ProductBusiness Get(int id)
        {
            return (from s in databaseContext.Product where s.Id == id select ProductMapper.Map(s)).FirstOrDefault();
        }
    }

}
