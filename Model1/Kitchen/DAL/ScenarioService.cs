using Model.Kitchen.BLL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.DAL
{
    public class ScenarioService
    {
        DatabaseContext databaseContext;
        public ScenarioService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(ScenarioBusiness scenario)
        {
            var entity = ScenarioMapper.Map(scenario);
            databaseContext.Scenario.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(ScenarioBusiness scenario)
        {
            var entity = databaseContext.Scenario.Find(scenario.Id);
            if (entity != null)
            {
                entity = ScenarioMapper.Map(scenario);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Scenario where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Scenario.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<ScenarioBusiness> GetAll()
        {
            return (from s in databaseContext.Scenario select ScenarioMapper.Map(s)).ToList();
        }
        public ScenarioBusiness GetByid(int id)
        {
            return (from s in databaseContext.Scenario where s.Id == id select ScenarioMapper.Map(s)).FirstOrDefault();
        }
    }
}
