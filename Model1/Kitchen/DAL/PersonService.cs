using Model.Kitchen.BLL;
using System.Collections.Generic;
using System.Linq;

namespace Model.Kitchen.DAL
{
    class PersonService
    {
        DatabaseContext databaseContext;
        public PersonService()
        {
            databaseContext = new DatabaseContext();
        }
        public void Add(PersonBusiness person)
        {
            var entity = PersonMapper.Map(person);
            databaseContext.Person.Add(entity);
            databaseContext.SaveChanges();
        }
        public void Update(PersonBusiness person)
        {
            var entity = databaseContext.Person.Find(person.Id);
            if (entity != null)
            {
                entity = PersonMapper.Map(person);
                databaseContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = (from s in databaseContext.Person where s.Id == id select s).FirstOrDefault();
            if (entity != null)
            {
                databaseContext.Person.Remove(entity);
                databaseContext.SaveChanges();
            }
        }
        public List<PersonBusiness> GetAll()
        {
            return (from s in databaseContext.Person select PersonMapper.Map(s)).ToList();
        }
        public PersonBusiness GetByid(int id)
        {
            return (from s in databaseContext.Person where s.Id == id select PersonMapper.Map(s)).FirstOrDefault();
        }
    }
}
