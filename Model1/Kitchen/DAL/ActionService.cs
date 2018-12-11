using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.Kitchen.DAL
{
    public class ActionService
    {
        DatabaseContext databaseContext;
        public ActionService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ActionBusiness action)
        {
            var entity = ActionMapper.Map(action);
            databaseContext.Action.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ActionBusiness action)
        {
            var entity = databaseContext.Action.Find(action.Id);
            if (entity != null)
            {
                entity = ActionMapper.Map(action);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Action where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Action.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ActionBusiness> GetAll()
        {
            return (from a in databaseContext.Action.Include(i => i.Person) select ActionMapper.Map(a)).ToList();
        }
        public ActionBusiness GetById(int id)
        {
            return (from s in databaseContext.Action where s.Id == id select ActionMapper.Map(s)).FirstOrDefault();
        }
    }
}
