using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;


namespace Model.Kitchen.BLL
{
    public class ComposeMapper
    {
        public static ComposeBusiness Map(ComposeDao compose)
        {
            return new ComposeBusiness
            {
                Position = compose.Position,
                Action = compose.Action != null ? ActionMapper.Map(compose.Action) : null,
                Scenario = compose.Scenario != null ? ScenarioMapper.Map(compose.Scenario) : null
            };
        }
        public static ComposeDao Map(ComposeBusiness compose)
        {
            return new ComposeDao
            {
                Position = compose.Position,
                Action = compose.Action != null ? ActionMapper.Map(compose.Action) : null,
                Scenario = compose.Scenario != null ? ScenarioMapper.Map(compose.Scenario) : null
            };
        }

        public static List<ComposeBusiness> Map(List<ComposeDao> compose)
        {
            return (from c in compose select Map(c)).ToList();
        }
    }
}
