using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Database.Lib
{
    public class PersonRepository
    {
        private readonly HumanResourceContext db;

        public PersonRepository(HumanResourceContext db)
        {
            this.db = db;
        }    

        public Person Find(int id)
        {
            return db.People.Find(id);
        }

        public void Save(Person person)
        {
            var current = db.People.Find(person.Id);

            if (current == null)
            {
                db.People.Add(person);
            }
            else
            {
                current.LastName = person.LastName;
                current.FirstName = person.FirstName;
                current.DateOfBirth = person.DateOfBirth;
            }
        }

        public IEnumerable<Person> SearchByLastName(string lastName)
        {
            return db.People.Where(p => p.LastName == lastName).ToArray();
        }
    }
}
