using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Infra.Data.Context
{
    public class PersonWebAPIContext : DbContext
    {
        public PersonWebAPIContext(DbContextOptions<PersonWebAPIContext> options) : base(options)
        {

        }

        #region Db_Set

        public DbSet<Person> Persons { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<PersonGroup> PersonGroups { get; set; }

        #endregion Db_Set

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonWebAPIContext).Assembly);
        }

    }
}
