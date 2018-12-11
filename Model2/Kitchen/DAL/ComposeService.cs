using Model.Kitchen.BLL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Model.Kitchen.DAL
{
    public class ComposeService
    {
        DatabaseContext databaseContext;
        public ComposeService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ComposeBusiness compose)
        {
            var entity = ComposeMapper.Map(compose);
            databaseContext.Compose.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ComposeBusiness compose)
        {
            var entity = databaseContext.Compose.Find(compose.Action.Id, compose.Scenario.Id);
            if (entity != null)
            {
                entity = ComposeMapper.Map(compose);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int actionId, int scenaryId)
        {
            var entity = (from c in databaseContext.Compose where c.Action.Id == actionId where c.Scenario.Id == scenaryId select c).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Compose.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ComposeBusiness> GetAll()
        {
            return (from c in databaseContext.Compose.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person) select ComposeMapper.Map(c)).ToList();
        }
        public List<ComposeBusiness> GetByScenario(int scenarioId)
        {
            return (from c in databaseContext.Compose.Include(i => i.Action).Include(i => i.Scenario).Include(i => i.Action.Person) where c.ScenarioId == scenarioId select ComposeMapper.Map(c)).ToList();
        }
    }
}
