using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class AddressConfig : EntityTypeConfiguration<Address>
    {
        public AddressConfig()
        {
            ToTable("Addresses");

            HasKey(a => a.AddressId);

            Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar");

            Property(a => a.Complement)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar");

            Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnType("varchar");

            HasRequired(a => a.Client)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.ClientId);
        }
    }
}
