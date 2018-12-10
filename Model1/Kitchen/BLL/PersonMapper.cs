using Model.Kitchen.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.BLL
{
    public class PersonMapper
    {
        public static PersonBusiness Map(PersonDao person)
        {
            return new PersonBusiness
            {
                id = person.id,
                role = person.role
            };
        }
        public static PersonDao Map(PersonBusiness person)
        {
            return new PersonDao
            {
                id = person.id,
                role = person.role
            };
        }

        public static List<PersonBusiness> Map(List<PersonDao> person)
        {
            return (from p in person select Map(p)).ToList();
        }
    }
}
