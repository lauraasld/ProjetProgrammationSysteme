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
                Id = person.Id,
                Role = person.Role
            };
        }
        public static PersonDao Map(PersonBusiness person)
        {
            return new PersonDao
            {
                Id = person.Id,
                Role = person.Role
            };
        }

        public static List<PersonBusiness> Map(List<PersonDao> person)
        {
            return (from p in person select Map(p)).ToList();
        }
    }
}
