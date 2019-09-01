using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Database.Lib;
using Xunit;

namespace TDD.Database.Tests
{
    public class PhoneNumberTests : IClassFixture<DatabaseTestFixture>
    {
        private readonly DatabaseTestFixture context;
        private readonly UnitOfWork persistence;
        private readonly HumanResourceContext db;

        public PhoneNumberTests(DatabaseTestFixture context)
        {
            this.context = context;
            this.persistence = context.Persistence;
            this.db = context.Database;
        }

        [Fact]
        public void Area_Code_Is_Required()
        {
            // arrange
            var person = new Person("roger", "spratley", new DateTime(1925, 3, 21));
            persistence.People.Save(person);
            persistence.Commit();

            // act
            var number = new PhoneNumber("919", "858", "8383");
            persistence.PhoneNumbers.Save(person, number);
            persistence.Commit();

            // assert
            var rec = db.PhoneNumbers.Single(p => p.Number == "8383");

            Assert.NotNull(rec);
        }
    }
}
