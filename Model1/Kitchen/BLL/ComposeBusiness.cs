using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Kitchen.BLL
{
    class ComposeBusiness
    {
        public int Position { get; set; }
        public PersonBusiness Person;
        public ScenaryBusiness Scenary;
    }
}
