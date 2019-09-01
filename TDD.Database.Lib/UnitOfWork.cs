using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Database.Lib
{
    public class UnitOfWork
    {
        private readonly HumanResourceContext db;

        public UnitOfWork(HumanResourceContext db)
        {
            this.db = db;

            this.People = new PersonRepository(db);
            this.PhoneNumbers = new PhoneNumberRepository(db);
        }

        public PersonRepository People { get; private set; }

        public PhoneNumberRepository PhoneNumbers { get; private set; }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
