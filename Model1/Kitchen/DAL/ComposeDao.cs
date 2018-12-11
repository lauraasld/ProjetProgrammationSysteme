using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Kitchen.DAL
{
    public class ComposeDao
    {
        public int Position { get; set; }

        public int ActionId { get; set; }
        [Key, Column(Order = 1)]
        public virtual ActionDao Action { get; set; }
        public int ScenaryId { get; set; }
        [Key, Column(Order = 0)]
        public virtual ScenaryDao Scenary { get; set; }
    }
}
