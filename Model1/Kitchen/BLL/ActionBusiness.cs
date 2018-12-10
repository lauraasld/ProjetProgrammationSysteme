using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Kitchen.BLL
{
    class ActionBusiness
    {
        public int Id;
        public string Name { get; set; }
        public int Value { get; set; }
        public PersonBusiness Person;
    }
}
