using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL
{
    public class ActionDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("personId")]
        public virtual PersonDao Person { get; set; }
    }
}
