using Model.Kitchen.BLL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.DAL
{
    class ScenaryService
    {
        DatabaseContext databaseContext;
        public ScenaryService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ScenaryBusiness scenary)
        {
            var entity = ScenaryMapper.Map(scenary);
            databaseContext.Scenary.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ScenaryBusiness scenary)
        {
            var entity = databaseContext.Scenary.Find(scenary.Id);
            if (entity != null)
            {
                entity = ScenaryMapper.Map(scenary);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Scenary where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Scenary.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ScenaryBusiness> GetAll()
        {
            return (from s in databaseContext.Scenary select ScenaryMapper.Map(s)).ToList();
        }
        public ScenaryBusiness GetByid(int id)
        {
            return (from s in databaseContext.Scenary where s.Id == id select ScenaryMapper.Map(s)).FirstOrDefault();
        }
    }
}
