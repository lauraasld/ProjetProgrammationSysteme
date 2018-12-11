using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Kitchen.BLL
{
    public class ComposeBusiness
    {
        public int Position { get; set; }
        public ActionBusiness Action { get; set; }
        public ScenaryBusiness Scenary { get; set; }
    }
}
