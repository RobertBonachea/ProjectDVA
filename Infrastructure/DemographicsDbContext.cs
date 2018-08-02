using System.Data.Common;
using System.Data.Entity;
using Domain;
using Domain.Entities;

namespace Infrastructure
{
    public class DemographicsDbContext : DbContext, IDbContext
    {
       
        public DemographicsDbContext()
           : base("DemographicDb")
        {
        }
              

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasRequired(t => t.Person)
                .WithRequiredDependent(t => t.Address)
                .WillCascadeOnDelete(true);
            
        }

    }
}
