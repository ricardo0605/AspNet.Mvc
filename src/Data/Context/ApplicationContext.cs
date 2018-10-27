using Data.EntityConfig;
using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
    }
}
