using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Kitchen.DAL
{
    class ComposeDao
    {
        public int Position { get; set; }
        public int PersonId { get; set; }
        public virtual PersonDao Person { get; set; }
        public int ScenaryId { get; set; }
        public virtual ScenaryDao Scenary { get; set; }
    }
}
