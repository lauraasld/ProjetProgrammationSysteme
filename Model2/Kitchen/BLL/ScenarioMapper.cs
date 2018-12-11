using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL
{
    public class ScenarioMapper
    {
        public static ScenarioBusiness Map(ScenarioDao scenario)
        {
            return new ScenarioBusiness
            {
                Id = scenario.Id,
                Title = scenario.Title
            };
        }
        public static ScenarioDao Map(ScenarioBusiness scenario)
        {
            return new ScenarioDao
            {
                Id = scenario.Id,
                Title = scenario.Title
            };
        }

        public static List<ScenarioBusiness> Map(List<ScenarioDao> scenario)
        {
            return (from s in scenario select Map(s)).ToList();
        }
    }
}
