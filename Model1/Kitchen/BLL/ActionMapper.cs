using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL
{
    class ActionMapper
    {
        public static ActionBusiness Map(ActionDao action)
        {
            return new ActionBusiness
            {
                Id = action.Id,
                Name = action.Name,
                Value = action.Value,
                Person = action.Person != null ? PersonMapper.Map(action.Person) : null
            };
        }
        public static ActionDao Map(ActionBusiness action)
        {
            return new ActionDao
            {
                Id = action.Id,
                Name = action.Name,
                Value = action.Value,
                PersonId = action.Person.Id
            };
        }

        public static List<ActionBusiness> Map(List<ActionDao> action)
        {
            return (from a in action select Map(a)).ToList();
        }
    }
}
