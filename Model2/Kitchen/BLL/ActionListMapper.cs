using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;


namespace Model.Kitchen.BLL
{
    public class ActionListMapper
    {
        public static ActionListBusiness Map(ActionList actionList)
        {
            return new ActionListBusiness
            {
                Position = actionList.Position,
                Action = actionList.Action != null ? ActionMapper.Map(actionList.Action) : null,
                Scenario = actionList.Scenario != null ? ScenarioMapper.Map(actionList.Scenario) : null
            };
        }
        public static ActionList Map(ActionListBusiness actionList)
        {
            return new ActionList
            {
                Position = actionList.Position,
                ActionId = actionList.Action.Id,
                ScenarioId = actionList.Scenario.Id
            };
        }

        public static List<ActionListBusiness> Map(List<ActionList> actionList)
        {
            return (from c in actionList select Map(c)).ToList();
        }
    }
}
