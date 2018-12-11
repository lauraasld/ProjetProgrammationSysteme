using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Kitchen.BLL
{
    public class ActionBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public PersonBusiness Person { get; set; }
    }
}
