using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Kitchen.DAL
{
    public class ActionsListDao
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int ActionId { get; set; }
        [ForeignKey ("actionId")]
        public virtual ActionDao Action { get; set; }
        public int ScenarioId { get; set; }
        [ForeignKey ("scenarioId")]
        public virtual ScenarioDao Scenario { get; set; }
    }
}
