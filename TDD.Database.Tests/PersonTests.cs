using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Database.Lib;
using Xunit;

namespace TDD.Database.Tests
{
    public class PeopleRepositoryTests : IClassFixture<DatabaseTestFixture>
    {
        private readonly DatabaseTestFixture context;
        private readonly UnitOfWork persistence;

        public PeopleRepositoryTests(DatabaseTestFixture context)
        {
            this.context = context;
            this.persistence = context.Persistence;
        }


        [Fact(DisplayName = "People can be persisted to database")]
        public void Inserting_Person_Causes_DB_Write()
        {
            // arrange
            var person = new Person("roger", "spratley", new DateTime(1925, 3, 21));

            // act
            persistence.People.Save(person);
            persistence.Commit();

            // assert
            Assert.NotEqual(default(int), person.Id);            
        }


        [Theory(DisplayName = "People can be searched by last name")]
        [InlineData("spratley", 1)]
        [InlineData("johnson", 0)]
        public void Find_People_By_LastName(string lastName, int expectedCount)
        {
            // arrange
            context.ResetPeople();

            var person = new Person("roger", "spratley", new DateTime(1925, 3, 21));
            persistence.People.Save(person);
            persistence.Commit();

            // act
            IEnumerable<Person> results = persistence.People.SearchByLastName(lastName);

            // assert
            Assert.Equal(expectedCount, results.Count());
        }
    }
}
