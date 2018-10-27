using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            ToTable("Clients");

            HasKey(c => c.ClientId);

            Property(c => c.Active)
                .IsRequired();

            Property(c => c.BirthOfDate)
                .IsRequired();

            Property(c => c.CPF)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF")
                    {
                        IsUnique = true
                    }
                ));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            Property(c => c.RegistryDate)
                .IsRequired();
        }
    }
}
