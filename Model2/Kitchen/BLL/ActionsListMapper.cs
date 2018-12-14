using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;


namespace Model.Kitchen.BLL
{
    public class ActionsListMapper
    {
        public static ActionsListBusiness Map(ActionsListDao actionsList)
        {
            return new ActionsListBusiness
            {
                Position = actionsList.Position,
                Action = actionsList.Action != null ? ActionMapper.Map(actionsList.Action) : null,
                Scenario = actionsList.Scenario != null ? ScenarioMapper.Map(actionsList.Scenario) : null
            };
        }
        public static ActionsListDao Map(ActionsListBusiness actionsList)
        {
            return new ActionsListDao
            {
                Position = actionsList.Position,
                ActionId = actionsList.Action.Id,
                ScenarioId = actionsList.Scenario.Id
            };
        }

        public static List<ActionsListBusiness> Map(List<ActionsListDao> actionsList)
        {
            return (from c in actionsList select Map(c)).ToList();
        }
    }
}
