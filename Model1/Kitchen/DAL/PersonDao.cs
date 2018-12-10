using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL
{
    public class PersonDao
    {
        public int Id;
        public string Role { get; set; }
    }
}
