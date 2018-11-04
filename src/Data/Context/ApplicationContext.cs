using Data.EntityConfig;
using Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new ClientConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("RegistryDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegistryDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("RegistryDate").IsModified = false;

            }

            return base.SaveChanges();
        }
    }
}
