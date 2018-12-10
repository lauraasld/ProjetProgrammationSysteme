using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Model.Kitchen.DAL;

namespace Model.Kitchen.DAL
{
    public class StorageService
    {
        DatabaseContext databaseContext;
        public StorageService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(StorageBusiness storage)
        {
            var entity = StorageMapper.Map(storage);
            databaseContext.Storage.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(StorageBusiness storage)
        {
            var entity = databaseContext.Storage.Find(storage.Id);
            if (entity != null)
            {
                entity = StorageMapper.Map(storage);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Storage where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Storage.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<StorageBusiness> GetAll()
        {
            return (from s in databaseContext.Storage.Include(i => i.Product) select StorageMapper.Map(s)).ToList();
        }
        public StorageBusiness GetById(int id)
        {
            return (from s in databaseContext.Storage where s.Id == id select StorageMapper.Map(s)).FirstOrDefault();
        }
        public List<StorageBusiness> GetByName(string name)
        {
            return (from s in databaseContext.Storage where s.Product.Name == name select StorageMapper.Map(s)).ToList();
        }
    }
}