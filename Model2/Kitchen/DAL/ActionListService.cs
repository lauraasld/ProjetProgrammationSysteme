using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.Kitchen.DAL
{
    public class ActionListService
    {
        DatabaseContext databaseContext;
        public ActionListService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ActionListBusiness actionList)
        {
            var entity = ActionListMapper.Map(actionList);
            databaseContext.ActionList.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ActionListBusiness actionList)
        {
            var entity = databaseContext.ActionList.Find(actionList.Id);
            if (entity != null)
            {
                entity = ActionListMapper.Map(actionList);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from c in databaseContext.ActionList where c.Id == id select c).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.ActionList.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ActionListBusiness> GetAll()
        {
            return (from c in databaseContext.ActionList.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person) select ActionListMapper.Map(c)).ToList();
        }
        public List<ActionListBusiness> GetByScenario(int scenarioId)
        {
            return (from c in databaseContext.ActionList.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person) where c.ScenarioId == scenarioId select ActionListMapper.Map(c)).ToList();
        }
    }
}
