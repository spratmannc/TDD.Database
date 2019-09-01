using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Database.Lib
{
    public class HumanResourceContext : DbContext
    {
        public HumanResourceContext()
        {
        }

        public HumanResourceContext(DbContextOptions<HumanResourceContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
