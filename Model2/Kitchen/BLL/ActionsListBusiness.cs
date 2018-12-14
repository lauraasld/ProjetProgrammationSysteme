using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Kitchen.BLL
{
    public class ActionsListBusiness
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public ActionBusiness Action { get; set; }
        public ScenarioBusiness Scenario { get; set; }
    }
}
