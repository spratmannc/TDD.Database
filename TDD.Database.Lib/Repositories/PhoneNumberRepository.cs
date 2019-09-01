using System.Linq;

namespace TDD.Database.Lib
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private HumanResourceContext db;

        public PhoneNumberRepository(HumanResourceContext db)
        {
            this.db = db;
        }

        public PhoneNumber Find(int personId)
        {
            return db.PhoneNumbers.Find(personId);
        }

        public void Save(Person person, PhoneNumber number)
        {
            var id = db.People.FirstOrDefault(p => p.FirstName == person.FirstName &&
                                                   p.LastName == person.LastName &&
                                                   p.DateOfBirth == person.DateOfBirth).Id;

            var record = db.PhoneNumbers.FirstOrDefault(p => p.PersonId == id);

            if (record == null)
            {
                db.PhoneNumbers.Add(number);
            }
            else
            {
                record.AreaCode = number.AreaCode;
                record.Exchange = number.Exchange;
                record.Number = number.Number;
            }

            db.SaveChanges();
        }
    }
}