using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL
{
    class ActionDao
    {
        public int Id;
        public string Name { get; set; }
        public int Value { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual PersonDao Person { get; set; }
    }
}
