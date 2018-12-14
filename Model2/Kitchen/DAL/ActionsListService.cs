using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.Kitchen.DAL
{
    public class ActionsListService
    {
        DatabaseContext databaseContext;
        public ActionsListService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ActionsListBusiness actionsList)
        {
            var entity = ActionsListMapper.Map(actionsList);
            databaseContext.ActionsList.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ActionsListBusiness actionsList)
        {
            var entity = databaseContext.ActionsList.Find(actionsList.Id);
            if (entity != null)
            {
                entity = ActionsListMapper.Map(actionsList);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from c in databaseContext.ActionsList where c.Id == id select c).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.ActionsList.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ActionsListBusiness> GetAll()
        {
            return (from c in databaseContext.ActionsList.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person) select ActionsListMapper.Map(c)).ToList();
        }
        public List<ActionsListBusiness> GetByScenario(int scenarioId)
        {
            return (from c in databaseContext.ActionsList.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person).OrderBy(i => i.Position) where c.ScenarioId == scenarioId select ActionsListMapper.Map(c)).ToList();
        }
    }
}
