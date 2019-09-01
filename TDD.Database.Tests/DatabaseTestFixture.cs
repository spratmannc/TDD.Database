using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Database.Lib;

namespace TDD.Database.Tests
{
    public class DatabaseTestFixture
    {
        public DatabaseTestFixture()
        {
            var options = new DbContextOptionsBuilder<HumanResourceContext>()
                            .UseInMemoryDatabase("HR")
                            .Options;

            this.Database = new HumanResourceContext(options);

            this.Persistence = new UnitOfWork(Database);
        }

        public HumanResourceContext Database { get; }

        public UnitOfWork Persistence { get; }

        internal void ResetTable<T>(DbSet<T> table) where T : class
        {
            table.RemoveRange(table);
            Database.SaveChanges();
        }

        internal void ResetPeople()
        {
            ResetTable(Database.People);
        }
    }
}
