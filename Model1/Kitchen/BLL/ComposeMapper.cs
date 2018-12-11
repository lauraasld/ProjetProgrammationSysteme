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
                Scenary = compose.Scenary != null ? ScenaryMapper.Map(compose.Scenary) : null
            };
        }
        public static ComposeDao Map(ComposeBusiness compose)
        {
            return new ComposeDao
            {
                Position = compose.Position,
                Action = compose.Action != null ? ActionMapper.Map(compose.Action) : null,
                Scenary = compose.Scenary != null ? ScenaryMapper.Map(compose.Scenary) : null
            };
        }

        public static List<ComposeBusiness> Map(List<ComposeDao> compose)
        {
            return (from c in compose select Map(c)).ToList();
        }
    }
}
