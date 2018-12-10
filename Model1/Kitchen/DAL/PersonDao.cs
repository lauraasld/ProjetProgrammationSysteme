using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Kitchen.DAL
{
    public class PersonDao
    {
        public int id;
        public string role { get; set; }
    }
}
