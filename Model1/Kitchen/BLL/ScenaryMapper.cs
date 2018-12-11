using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL
{
    public class ScenaryMapper
    {
        public static ScenaryBusiness Map(ScenaryDao scenary)
        {
            return new ScenaryBusiness
            {
                Id = scenary.Id,
                Title = scenary.Title
            };
        }
        public static ScenaryDao Map(ScenaryBusiness scenary)
        {
            return new ScenaryDao
            {
                Id = scenary.Id,
                Title = scenary.Title
            };
        }

        public static List<ScenaryBusiness> Map(List<ScenaryDao> scenary)
        {
            return (from s in scenary select Map(s)).ToList();
        }
    }
}
